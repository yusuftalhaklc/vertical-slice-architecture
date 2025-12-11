using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Query
{
    public record GetAppUserProfilesQuery : IRequest<List<GetAppUserProfilesResult>>
    {
    }
}

