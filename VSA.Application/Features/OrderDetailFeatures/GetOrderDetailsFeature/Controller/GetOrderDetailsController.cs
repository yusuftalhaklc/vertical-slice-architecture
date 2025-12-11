using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Query;

namespace VSA.Application.Features.OrderDetailFeatures.GetOrderDetailsFeature.Controller
{
    [ApiExplorerSettings(GroupName = "OrderDetail")]
    public class GetOrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetOrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/api/orderdetails")]
        public async Task<IActionResult> GetOrderDetails()
        {
            var query = new GetOrderDetailsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

