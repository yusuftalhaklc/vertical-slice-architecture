using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Command;

namespace VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUserProfile")]
    public class CreateAppUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateAppUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/appuserprofiles")]
        public async Task<IActionResult> CreateAppUserProfile([FromBody] CreateAppUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

