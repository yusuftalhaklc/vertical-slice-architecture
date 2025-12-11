using Microsoft.OpenApi.Models;
using VSA.Application.DependencyResolvers;
using VSA.Application.Contexts;
using VSA.Application.Features.CategoryFeatures.CreateCategoryFeature.Controller;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextService();
builder.Services.AddMediatrService();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(CreateCategoryController).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VSA API", Version = "v1" });
    c.TagActionsBy(api =>
    {
        if (api.GroupName != null)
            return new[] { api.GroupName };
        return new[] { "Default" };
    });
    c.DocInclusionPredicate((name, api) => true);
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VSA API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
