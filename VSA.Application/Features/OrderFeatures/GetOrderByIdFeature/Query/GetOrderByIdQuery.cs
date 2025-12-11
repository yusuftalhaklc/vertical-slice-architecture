using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Result;

namespace VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Query
{
    public record GetOrderByIdQuery : IRequest<GetOrderByIdResult>
    {
        public int Id { get; set; }
    }
}

