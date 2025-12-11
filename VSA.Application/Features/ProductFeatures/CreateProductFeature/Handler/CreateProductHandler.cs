using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VSA.Application.Contexts;
using VSA.Application.Entities;
using VSA.Application.Features.ProductFeatures.CreateProductFeature.Command;
using VSA.Application.Features.ProductFeatures.CreateProductFeature.Result;

namespace VSA.Application.Features.ProductFeatures.CreateProductFeature.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly AppDbContext _context;
        public CreateProductHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId,
                CreatedDate = DateTime.Now
            };
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateProductResult { Id = product.Id };
        }
    }
}

