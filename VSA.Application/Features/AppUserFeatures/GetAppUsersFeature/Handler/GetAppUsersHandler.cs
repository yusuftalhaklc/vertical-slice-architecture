using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Application.Contexts;
using VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Query;
using VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Result;

namespace VSA.Application.Features.AppUserFeatures.GetAppUsersFeature.Handler
{
    public class GetAppUsersHandler : IRequestHandler<GetAppUsersQuery, List<GetAppUsersResult>>
    {
        private readonly AppDbContext _context;
        public GetAppUsersHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAppUsersResult>> Handle(GetAppUsersQuery request, CancellationToken cancellationToken)
        {
            var appUsers = await _context.AppUsers
                .Select(x => new GetAppUsersResult
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                })
                .ToListAsync(cancellationToken);

            return appUsers;
        }
    }
}

