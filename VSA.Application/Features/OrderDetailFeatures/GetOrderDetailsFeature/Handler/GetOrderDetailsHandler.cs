using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Query;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Handler
{
    public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetailsQuery, List<GetOrderDetailsResult>>
    {
        private readonly AppDbContext _context;
        public GetOrderDetailsHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetOrderDetailsResult>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _context.OrderDetails
                .Select(x => new GetOrderDetailsResult
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .ToListAsync(cancellationToken);

            return orderDetails;
        }
    }
}

