using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.OrderFeatures.GetOrdersFeature.Query;
using VSA.Application.Features.OrderFeatures.GetOrdersFeature.Result;

namespace VSA.Application.Features.OrderFeatures.GetOrdersFeature.Handler
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<GetOrdersResult>>
    {
        private readonly AppDbContext _context;
        public GetOrdersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetOrdersResult>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .Select(x => new GetOrdersResult
                {
                    Id = x.Id,
                    ShippingAddress = x.ShippingAddress,
                    AppUserId = x.AppUserId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .ToListAsync(cancellationToken);

            return orders;
        }
    }
}

