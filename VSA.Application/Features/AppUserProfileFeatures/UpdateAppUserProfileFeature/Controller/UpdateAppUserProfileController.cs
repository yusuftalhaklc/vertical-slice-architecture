using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Command;

namespace VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUserProfile")]
    public class UpdateAppUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateAppUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/api/appuserprofiles/{id}")]
        public async Task<IActionResult> UpdateAppUserProfile(int id, [FromBody] UpdateAppUserProfileCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }
    }
}

