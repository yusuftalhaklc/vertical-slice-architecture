using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.ProductFeatures.UpdateProductFeature.Result;

namespace VSA.Application.Features.ProductFeatures.UpdateProductFeature.Command
{
    public record UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}

