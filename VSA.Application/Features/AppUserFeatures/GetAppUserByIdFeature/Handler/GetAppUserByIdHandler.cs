using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Query;
using VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.GetAppUserByIdFeature.Handler
{
    public class GetAppUserByIdHandler : IRequestHandler<GetAppUserByIdQuery, GetAppUserByIdResult>
    {
        private readonly AppDbContext _context;
        public GetAppUserByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAppUserByIdResult> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var appUser = await _context.AppUsers
                .Where(x => x.Id == request.Id)
                .Select(x => new GetAppUserByIdResult
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return appUser;
        }
    }
}

