using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Result;

namespace VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Query
{
    public record GetOrderDetailsQuery : IRequest<List<GetOrderDetailsResult>>
    {
    }
}

