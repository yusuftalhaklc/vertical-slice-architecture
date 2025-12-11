using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VSA.Application.Contexts;
using VSA.Application.Entities;
using VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Command;
using VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Handler
{
    public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailCommand, CreateOrderDetailResult>
    {
        private readonly AppDbContext _context;
        public CreateOrderDetailHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateOrderDetailResult> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                CreatedDate = DateTime.Now
            };
            await _context.OrderDetails.AddAsync(orderDetail, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateOrderDetailResult { Id = orderDetail.Id };
        }
    }
}

