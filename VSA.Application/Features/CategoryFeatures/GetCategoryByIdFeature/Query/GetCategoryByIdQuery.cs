using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Result;

namespace VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Query
{
    public record GetCategoryByIdQuery : IRequest<GetCategoryByIdResult>
    {
        public int Id { get; set; }
    }
}
