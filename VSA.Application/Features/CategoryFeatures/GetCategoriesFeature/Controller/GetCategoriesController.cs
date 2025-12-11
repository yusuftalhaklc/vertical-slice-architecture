using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Query;

namespace VSA.Application.Features.CategoryFeatures.GetCategoriesFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Category")]
    public class GetCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/categories")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

