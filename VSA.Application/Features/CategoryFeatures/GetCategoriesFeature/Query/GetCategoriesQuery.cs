using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Result;

namespace VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Query
{
    public record GetCategoriesQuery : IRequest<List<GetCategoriesResult>>
    {
    }
}
