using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Query;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfileByIdFeature.Handler
{
    public class GetAppUserProfileByIdHandler : IRequestHandler<GetAppUserProfileByIdQuery, GetAppUserProfileByIdResult>
    {
        private readonly AppDbContext _context;
        public GetAppUserProfileByIdHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetAppUserProfileByIdResult> Handle(GetAppUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _context.AppUserProfiles
                .Where(x => x.Id == request.Id)
                .Select(x => new GetAppUserProfileByIdResult
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    AppUserId = x.AppUserId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .FirstOrDefaultAsync(cancellationToken);

            return appUserProfile;
        }
    }
}

