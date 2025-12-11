using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Query;
using VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Result;

namespace VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Handler
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdResult>
    {
        private readonly AppDbContext _context;
        public GetOrderByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetOrderByIdResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Where(x => x.Id == request.Id)
                .Select(x => new GetOrderByIdResult
                {
                    Id = x.Id,
                    ShippingAddress = x.ShippingAddress,
                    AppUserId = x.AppUserId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return order;
        }
    }
}

