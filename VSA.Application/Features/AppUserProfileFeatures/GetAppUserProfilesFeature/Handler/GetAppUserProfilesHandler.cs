using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Query;
using VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.GetAppUserProfilesFeature.Handler
{
    public class GetAppUserProfilesHandler : IRequestHandler<GetAppUserProfilesQuery, List<GetAppUserProfilesResult>>
    {
        private readonly AppDbContext _context;
        public GetAppUserProfilesHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAppUserProfilesResult>> Handle(GetAppUserProfilesQuery request, CancellationToken cancellationToken)
        {
            var appUserProfiles = await _context.AppUserProfiles
                .Select(x => new GetAppUserProfilesResult
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    AppUserId = x.AppUserId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .ToListAsync(cancellationToken);

            return appUserProfiles;
        }
    }
}

