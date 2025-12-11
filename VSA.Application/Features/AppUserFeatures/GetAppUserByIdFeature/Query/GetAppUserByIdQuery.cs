using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Query
{
    public record GetAppUserByIdQuery : IRequest<GetAppUserByIdResult>
    {
        public int Id { get; set; }
    }
}

