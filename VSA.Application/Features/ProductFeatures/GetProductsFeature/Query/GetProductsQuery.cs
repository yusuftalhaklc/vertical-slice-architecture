using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.ProductFeatures.GetProductsFeature.Result;

namespace VSA.Application.Features.ProductFeatures.GetProductsFeature.Query
{
    public record GetProductsQuery : IRequest<List<GetProductsResult>>
    {
    }
}

