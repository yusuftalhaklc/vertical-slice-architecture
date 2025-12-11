using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Query
{
    public record GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdResult>
    {
        public int Id { get; set; }
    }
}

