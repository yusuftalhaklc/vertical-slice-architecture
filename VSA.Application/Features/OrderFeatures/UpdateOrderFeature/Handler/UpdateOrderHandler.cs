using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Command;
using VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Result;

namespace VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Handler
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        private readonly AppDbContext _context;
        public UpdateOrderHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (order == null)
                return new UpdateOrderResult { IsSuccess = false };

            order.ShippingAddress = request.ShippingAddress;
            order.AppUserId = request.AppUserId;
            order.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateOrderResult { IsSuccess = true };
        }
    }
}

