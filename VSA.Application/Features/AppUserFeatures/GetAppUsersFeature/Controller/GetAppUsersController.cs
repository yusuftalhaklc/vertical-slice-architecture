using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Query;

namespace VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUser")]
    public class GetAppUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/appusers")]
        public async Task<IActionResult> GetAppUsers()
        {
            var query = new GetAppUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

