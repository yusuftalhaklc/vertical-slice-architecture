using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Command
{
    public record CreateAppUserProfileCommand : IRequest<CreateAppUserProfileResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }
    }
}

