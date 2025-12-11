using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Command;

namespace VSA.Application.Features.OrderDetailFeatures.CreateOrderDetailFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "OrderDetail")]
    public class CreateOrderDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateOrderDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/api/orderdetails")]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

