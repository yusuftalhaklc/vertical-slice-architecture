using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Query;

namespace VSA.Application.Features.OrderFeatures.GetOrderByIdFeature.Controller
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Order")]
    public class GetOrderByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetOrderByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/orders/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

