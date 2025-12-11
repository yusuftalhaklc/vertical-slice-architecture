using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VSA.Application.DependencyResolvers
{
    public static class MediatrResolver
    {
        public static void AddMediatrService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}

