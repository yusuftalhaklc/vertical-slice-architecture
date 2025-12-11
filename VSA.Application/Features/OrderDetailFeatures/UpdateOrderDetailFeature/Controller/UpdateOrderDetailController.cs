using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Command;

namespace VSA.Application.Features.OrderDetailFeatures.UpdateOrderDetailFeature.Controller
{
    [ApiExplorerSettings(GroupName = "OrderDetail")]
    public class UpdateOrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UpdateOrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("/api/orderdetails/{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] UpdateOrderDetailCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return NotFound();
            return Ok(result);
        }
    }
}

