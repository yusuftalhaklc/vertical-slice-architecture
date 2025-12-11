using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Command
{
    public record UpdateAppUserCommand : IRequest<UpdateAppUserResult>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

