# .NET'te Vertical Slice Architecture (VSA)

Bu yazıda, **Vertical Slice Architecture (VSA)** mimarisini inceleyeceğiz.

## Vertical Slice Architecture Nedir?

**Vertical Slice Architecture (Dikey Dilim Mimarisi)**, uygulamanın her bir özelliğini (feature) bağımsız ve dikey dilimler halinde organize etmeyi amaçlayan bir mimari yaklaşımdır. Geleneksel katmanlı mimarilerin aksine, VSA her bir özelliği kendi içinde tam bir "dilim" olarak ele alır.

### Geleneksel Katmanlı Mimari vs VSA

**Geleneksel Katmanlı Mimari (Horizontal Layers):**
```
┌─────────────────────────────────────────┐
│           Presentation Layer            │
├─────────────────────────────────────────┤
│           Application Layer             │
├─────────────────────────────────────────┤
│             Domain Layer                │
├─────────────────────────────────────────┤
│         Infrastructure Layer            │
└─────────────────────────────────────────┘
```

**Vertical Slice Architecture:**
```
┌───────────┐ ┌───────────┐ ┌───────────┐ ┌───────────┐
│ Feature 1 │ │ Feature 2 │ │ Feature 3 │ │ Feature 4 │
│───────────│ │───────────│ │───────────│ │───────────│
│ Controller│ │ Controller│ │ Controller│ │ Controller│
│  Handler  │ │  Handler  │ │  Handler  │ │  Handler  │
│  Command  │ │   Query   │ │  Command  │ │   Query   │
└───────────┘ └───────────┘ └───────────┘ └───────────┘
```

## VSA'nın Avantajları

- **Bağımsız Özellik Geliştirme:** Her bir özellik kendi içinde izole edilmiştir.
- **Kolay Bakım ve Test:** Her dilim bağımsız olduğu için birim testleri daha kolay yazılır.
- **Daha Az Çakışma:** Ekip üyeleri farklı feature'lar üzerinde çalışırken kod çakışmaları minimuma iner.
- **CQRS Uyumu:** Command Query Responsibility Segregation deseni ile mükemmel uyum sağlar.

## Proje Yapısı

```
VSA/
├── VSA.sln
├── VSA.WebApi/
│   └── Program.cs
└── VSA.Application/
    ├── Entities/
    │   └── Category.cs
    └── Features/
        └── CategoryFeatures/
            └── CreateCategoryFeature/
                ├── Command/
                │   └── CreateCategoryCommand.cs
                ├── Handler/
                │   └── CreateCategoryHandler.cs
                └── Controller/
                    └── CreateCategoryController.cs
```

## Feature Yapısı

Her feature, belirli bir işlevi yerine getiren bağımsız bir dilimdir:

| Bileşen | Açıklama |
|---------|----------|
| **Command** | İşlemin giriş parametrelerini tanımlar |
| **Handler** | İş mantığını içerir |
| **Controller** | HTTP endpoint'ini tanımlar |

## Category Örneği

### Create Category Feature

**CreateCategoryCommand.cs:**
```csharp
public record CreateCategoryCommand : IRequest<int>
{
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
```

**CreateCategoryHandler.cs:**
```csharp
public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly AppDbContext _context;
    
    public CreateCategoryHandler(AppDbContext context) 
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            CategoryName = request.CategoryName,
            Description = request.Description
        };
        await _context.Categories.AddAsync(category, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}
```

**CreateCategoryController.cs:**
```csharp
[ApiController]
[ApiExplorerSettings(GroupName = "Category")]
public class CreateCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CreateCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/api/categories")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
```

## Request Akışı

```
HTTP Request
     │
     ▼
┌─────────────┐
│ Controller  │──── IMediator.Send(Command)
└─────────────┘
     │
     ▼
┌─────────────┐
│   MediatR   │──── Routes to Handler
└─────────────┘
     │
     ▼
┌─────────────┐
│   Handler   │──── Business Logic
└─────────────┘
     │
     ▼
┌─────────────┐
│  Database   │
└─────────────┘
```

## Sonuç

**Vertical Slice Architecture**, her feature'ın bağımsız bir dilim olarak ele alınmasını sağlar. MediatR ile birlikte kullanıldığında, kod daha temiz, test edilebilir ve sürdürülebilir hale gelir.

## Kaynak Kod

Projenin tamamına GitHub üzerinden erişebilirsiniz:

🔗 [https://github.com/yusuftalhaklc/vertical-slice-architecture](https://github.com/yusuftalhaklc/vertical-slice-architecture)
