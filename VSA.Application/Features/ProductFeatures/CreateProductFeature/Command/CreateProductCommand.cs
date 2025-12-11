using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.ProductFeatures.CreateProductFeature.Result;

namespace VSA.Application.Features.ProductFeatures.CreateProductFeature.Command
{
    public record CreateProductCommand : IRequest<CreateProductResult>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }
    }
}

