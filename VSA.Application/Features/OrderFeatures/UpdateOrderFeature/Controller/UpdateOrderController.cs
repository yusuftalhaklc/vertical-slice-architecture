using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Command;

namespace VSA.Application.Features.OrderFeatures.UpdateOrderFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Order")]
    public class UpdateOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/api/orders/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }
    }
}

