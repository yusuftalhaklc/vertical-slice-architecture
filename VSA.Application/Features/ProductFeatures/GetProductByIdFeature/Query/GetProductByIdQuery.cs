using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Result;

namespace VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Query
{
    public record GetProductByIdQuery : IRequest<GetProductByIdResult>
    {
        public int Id { get; set; }
    }
}

