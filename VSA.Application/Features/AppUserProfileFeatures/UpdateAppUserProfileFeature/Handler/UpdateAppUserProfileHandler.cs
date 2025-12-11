using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Command;
using VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.UpdateAppUserProfileFeature.Handler
{
    public class UpdateAppUserProfileHandler : IRequestHandler<UpdateAppUserProfileCommand, UpdateAppUserProfileResult>
    {
        private readonly AppDbContext _context;
        public UpdateAppUserProfileHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateAppUserProfileResult> Handle(UpdateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = await _context.AppUserProfiles
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (appUserProfile == null)
                return new UpdateAppUserProfileResult { IsSuccess = false };

            appUserProfile.FirstName = request.FirstName;
            appUserProfile.LastName = request.LastName;
            appUserProfile.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateAppUserProfileResult { IsSuccess = true };
        }
    }
}

