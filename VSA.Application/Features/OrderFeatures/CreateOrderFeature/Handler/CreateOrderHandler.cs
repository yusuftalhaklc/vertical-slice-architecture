using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VSA.Application.Contexts;
using VSA.Application.Entities;
using VSA.Application.Features.OrderFeatures.CreateOrderFeature.Command;
using VSA.Application.Features.OrderFeatures.CreateOrderFeature.Result;

namespace VSA.Application.Features.OrderFeatures.CreateOrderFeature.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, CreateOrderResult>
    {
        private readonly AppDbContext _context;
        public CreateOrderHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ShippingAddress = request.ShippingAddress,
                AppUserId = request.AppUserId,
                CreatedDate = DateTime.Now
            };
            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateOrderResult { Id = order.Id };
        }
    }
}

