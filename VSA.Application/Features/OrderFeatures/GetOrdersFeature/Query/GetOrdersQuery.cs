using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.OrderFeatures.GetOrdersFeature.Result;

namespace VSA.Application.Features.OrderFeatures.GetOrdersFeature.Query
{
    public record GetOrdersQuery : IRequest<List<GetOrdersResult>>
    {
    }
}

