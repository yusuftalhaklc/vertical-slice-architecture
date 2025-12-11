using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSA.Application.Features.CategoryFeatures.UpdateCategoryFeature.Command
{
    public record UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}

