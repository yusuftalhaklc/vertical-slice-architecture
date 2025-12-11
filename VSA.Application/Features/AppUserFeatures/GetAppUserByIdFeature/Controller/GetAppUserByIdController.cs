using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Query;

namespace VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "AppUser")]
    public class GetAppUserByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetAppUserByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/appusers/{id}")]
        public async Task<IActionResult> GetAppUserById(int id)
        {
            var query = new GetAppUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

