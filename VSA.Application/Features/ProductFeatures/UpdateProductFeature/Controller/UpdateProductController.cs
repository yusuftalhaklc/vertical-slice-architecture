using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.ProductFeatures.UpdateProductFeature.Command;

namespace VSA.Application.Features.ProductFeatures.UpdateProductFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Product")]
    public class UpdateProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/api/products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }
    }
}

