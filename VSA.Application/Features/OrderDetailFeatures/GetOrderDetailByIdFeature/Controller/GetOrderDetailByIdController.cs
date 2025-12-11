using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Query;

namespace VSA.Application.Features.OrderDetailFeatures.GetOrderDetailByIdFeature.Controller
{
    [ApiExplorerSettings(GroupName = "OrderDetail")]
    public class GetOrderDetailByIdController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetOrderDetailByIdController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/orderdetails/{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var query = new GetOrderDetailByIdQuery { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}

