using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Command
{
    public record CreateOrderDetailCommand : IRequest<CreateOrderDetailResult>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}

