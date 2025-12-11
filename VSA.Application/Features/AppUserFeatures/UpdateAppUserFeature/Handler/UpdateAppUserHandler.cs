using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Command;
using VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.UpdateAppUserFeature.Handler
{
    public class UpdateAppUserHandler : IRequestHandler<UpdateAppUserCommand, UpdateAppUserResult>
    {
        private readonly AppDbContext _context;
        public UpdateAppUserHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateAppUserResult> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _context.AppUsers
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (appUser == null)
                return new UpdateAppUserResult { IsSuccess = false };

            appUser.UserName = request.UserName;
            appUser.Password = request.Password;
            appUser.UpdatedDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
            return new UpdateAppUserResult { IsSuccess = true };
        }
    }
}

