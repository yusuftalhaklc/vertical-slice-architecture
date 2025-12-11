using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Command;

namespace VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUser")]
    public class UpdateAppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateAppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/api/appusers/{id}")]
        public async Task<IActionResult> UpdateAppUser(int id, [FromBody] UpdateAppUserCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }
    }
}

