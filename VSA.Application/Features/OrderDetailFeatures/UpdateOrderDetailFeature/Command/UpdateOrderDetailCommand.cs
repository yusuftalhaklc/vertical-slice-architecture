using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Command
{
    public record UpdateOrderDetailCommand : IRequest<UpdateOrderDetailResult>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

