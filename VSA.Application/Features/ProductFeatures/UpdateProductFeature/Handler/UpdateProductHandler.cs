using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.ProductFeatures.UpdateProductFeature.Command;
using VSA.Application.Features.ProductFeatures.UpdateProductFeature.Result;

namespace VSA.Application.Features.ProductFeatures.UpdateProductFeature.Handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly AppDbContext _context;
        public UpdateProductHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (product == null)
                return new UpdateProductResult { IsSuccess = false };

            product.ProductName = request.ProductName;
            product.UnitPrice = request.UnitPrice;
            product.CategoryId = request.CategoryId;
            product.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult { IsSuccess = true };
        }
    }
}

