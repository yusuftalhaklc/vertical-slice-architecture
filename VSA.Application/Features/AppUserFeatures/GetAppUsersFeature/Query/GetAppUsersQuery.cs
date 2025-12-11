using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Query
{
    public record GetAppUsersQuery : IRequest<List<GetAppUsersResult>>
    {
    }
}

