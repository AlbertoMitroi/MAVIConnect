using MAVI.DataAccess.Repositories;
using MAVI.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MAVI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.Load("MAVI.Application"))
            );  

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();

            return services;
        }
    }
}
