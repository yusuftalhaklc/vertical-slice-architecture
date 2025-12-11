using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.CategoryFeatures.UpdateCategoryFeature.Command;

namespace VSA.Application.Features.CategoryFeatures.UpdateCategoryFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Category")]
    public class UpdateCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/api/categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}

