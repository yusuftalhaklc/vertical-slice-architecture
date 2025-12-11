using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Query;

namespace VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUserProfile")]
    public class GetAppUserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAppUserProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/appuserprofiles")]
        public async Task<IActionResult> GetAppUserProfiles()
        {
            var query = new GetAppUserProfilesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

