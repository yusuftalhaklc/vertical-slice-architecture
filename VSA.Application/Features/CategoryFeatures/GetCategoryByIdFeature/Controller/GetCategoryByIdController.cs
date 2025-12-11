using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Query;

namespace VSA.Application.Features.CategoryFeatures.GetCategoryByIdFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Category")]
    public class GetCategoryByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetCategoryByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/categories/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

