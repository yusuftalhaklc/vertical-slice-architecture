using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderFeatures.CreateOrderFeature.Command;

namespace VSA.Application.Features.OrderFeatures.CreateOrderFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Order")]
    public class CreateOrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/orders")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

