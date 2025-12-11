using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Query;

namespace VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Controller
{
    [ApiExplorerSettings(GroupName = "AppUserProfile")]
    public class GetAppUserProfileByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAppUserProfileByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/appuserprofiles/{id}")]
        public async Task<IActionResult> GetAppUserProfileById(int id)
        {
            var query = new GetAppUserProfileByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

