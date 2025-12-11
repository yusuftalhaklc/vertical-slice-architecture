using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderFeatures.GetOrdersFeature.Query;

namespace VSA.Application.Features.OrderFeatures.GetOrdersFeature.Controller
{
    [ApiExplorerSettings(GroupName = "Order")]
    public class GetOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/orders")]
        public async Task<IActionResult> GetOrders()
        {
            var query = new GetOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

