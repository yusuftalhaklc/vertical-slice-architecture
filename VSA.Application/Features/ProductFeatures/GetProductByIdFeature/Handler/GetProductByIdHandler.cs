using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Query;
using VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Result;

namespace VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly AppDbContext _context;
        public GetProductByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(x => x.Id == request.Id)
                .Select(x => new GetProductByIdResult
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryId = x.CategoryId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return product;
        }
    }
}

