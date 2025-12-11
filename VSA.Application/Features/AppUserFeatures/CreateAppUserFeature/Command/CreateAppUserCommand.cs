using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Command
{
    public record CreateAppUserCommand : IRequest<CreateAppUserResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

