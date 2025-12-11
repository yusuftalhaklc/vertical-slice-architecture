using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VSA.Application.Contexts;
using VSA.Application.Entities;
using VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Command;
using VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Result;

namespace VSA.Application.Features.AppUserProfileFeatures.CreateAppUserProfileFeature.Handler
{
    public class CreateAppUserProfileHandler : IRequestHandler<CreateAppUserProfileCommand, CreateAppUserProfileResult>
    {
        private readonly AppDbContext _context;
        public CreateAppUserProfileHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateAppUserProfileResult> Handle(CreateAppUserProfileCommand request, CancellationToken cancellationToken)
        {
            var appUserProfile = new AppUserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                AppUserId = request.AppUserId,
                CreatedDate = DateTime.Now
            };
            await _context.AppUserProfiles.AddAsync(appUserProfile, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateAppUserProfileResult { Id = appUserProfile.Id };
        }
    }
}

