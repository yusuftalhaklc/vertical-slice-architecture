using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Query;
using VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Result;

namespace VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Handler
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResult>
    {
        private readonly AppDbContext _context;
        public GetCategoryByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Where(x => x.Id == request.Id)
                .Select(x => new GetCategoryByIdResult
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return category;
        }
    }
}

