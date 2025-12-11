using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using VSA.Application.Contexts;
using VSA.Application.Entities;
using VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Command;
using VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.CreateAppUserFeature.Handler
{
    public class CreateAppUserHandler : IRequestHandler<CreateAppUserCommand, CreateAppUserResult>
    {
        private readonly AppDbContext _context;
        public CreateAppUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateAppUserResult> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                UserName = request.UserName,
                Password = request.Password,
                CreatedDate = DateTime.Now
            };
            await _context.AppUsers.AddAsync(appUser, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateAppUserResult { Id = appUser.Id };
        }
    }
}

