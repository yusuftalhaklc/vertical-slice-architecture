using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Command;
using VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Handler
{
    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailCommand, UpdateOrderDetailResult>
    {
        private readonly AppDbContext _context;
        public UpdateOrderDetailHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderDetailResult> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (orderDetail == null)
                return new UpdateOrderDetailResult { IsSuccess = false };

            orderDetail.OrderId = request.OrderId;
            orderDetail.ProductId = request.ProductId;
            orderDetail.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateOrderDetailResult { IsSuccess = true };
        }
    }
}

