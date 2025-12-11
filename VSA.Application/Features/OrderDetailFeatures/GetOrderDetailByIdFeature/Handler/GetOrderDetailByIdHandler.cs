using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Query;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Handler
{
    public class GetOrderDetailByIdHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdResult>
    {
        private readonly AppDbContext _context;
        public GetOrderDetailByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetOrderDetailByIdResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _context.OrderDetails
                .Where(x => x.Id == request.Id)
                .Select(x => new GetOrderDetailByIdResult
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return orderDetail;
        }
    }
}

