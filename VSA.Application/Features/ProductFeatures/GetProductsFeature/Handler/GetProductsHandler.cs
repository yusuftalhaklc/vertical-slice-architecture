using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.ProductFeatures.GetProductsFeature.Query;
using VSA.Application.Features.ProductFeatures.GetProductsFeature.Result;

namespace VSA.Application.Features.ProductFeatures.GetProductsFeature.Handler
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<GetProductsResult>>
    {
        private readonly AppDbContext _context;
        public GetProductsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Select(x => new GetProductsResult
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryId = x.CategoryId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .ToListAsync(cancellationToken);

            return products;
        }
    }
}

