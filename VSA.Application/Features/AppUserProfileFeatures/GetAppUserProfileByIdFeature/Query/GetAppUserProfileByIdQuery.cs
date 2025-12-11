using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Query
{
    public record GetAppUserProfileByIdQuery : IRequest<GetAppUserProfileByIdResult>
    {
        public int Id { get; set; }
    }
}

