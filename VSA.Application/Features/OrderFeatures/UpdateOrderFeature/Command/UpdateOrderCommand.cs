using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Result;

namespace VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Command
{
    public record UpdateOrderCommand : IRequest<UpdateOrderResult>
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int? AppUserId { get; set; }
    }
}

