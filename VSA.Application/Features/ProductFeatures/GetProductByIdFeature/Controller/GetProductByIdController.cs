using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Query;

namespace VSA.Application.Features.ProductFeatures.GetProductByIdFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Product")]
    public class GetProductByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetProductByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

