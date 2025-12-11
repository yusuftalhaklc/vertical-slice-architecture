using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Query;
using VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Result;

namespace VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Handler
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesResult>>
    {
        private readonly AppDbContext _context;
        public GetCategoriesHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoriesResult>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .Select(x => new GetCategoriesResult
                {
                    Id = x.Id,
                    CategoryName = x.CategoryName,
                    Description = x.Description,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .ToListAsync(cancellationToken);

            return categories;
        }
    }
}

