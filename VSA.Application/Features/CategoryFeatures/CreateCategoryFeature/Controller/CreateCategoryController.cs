using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.CategoryFeatures.CreateCategoryFeature.Command;
namespace VSA.Application.Features.CategoryFeatures.CreateCategoryFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Category")]
    public class CreateCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/categories")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
