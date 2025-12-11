using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.ProductFeatures.CreateProductFeature.Command;

namespace VSA.Application.Features.ProductFeatures.CreateProductFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Product")]
    public class CreateProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

