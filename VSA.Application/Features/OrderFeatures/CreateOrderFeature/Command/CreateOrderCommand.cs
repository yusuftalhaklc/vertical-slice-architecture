using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderFeatures.CreateOrderFeature.Result;

namespace VSA.Application.Features.OrderFeatures.CreateOrderFeature.Command
{
    public record CreateOrderCommand : IRequest<CreateOrderResult>
    {
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}

