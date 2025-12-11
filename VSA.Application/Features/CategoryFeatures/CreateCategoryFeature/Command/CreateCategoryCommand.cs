using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSA.Application.Features.CategoryFeatures.CreateCategoryFeature.Command
{
    public record CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
