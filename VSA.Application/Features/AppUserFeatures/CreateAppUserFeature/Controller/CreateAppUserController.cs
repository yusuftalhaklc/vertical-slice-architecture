using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Command;

namespace VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUser")]
    public class CreateAppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateAppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/appusers")]
        public async Task<IActionResult> CreateAppUser([FromBody] CreateAppUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

