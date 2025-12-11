using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Command
{
    public record UpdateAppUserProfileCommand : IRequest<UpdateAppUserProfileResult>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

