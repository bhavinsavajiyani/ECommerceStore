using EComm_Store_Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace EComm_Store_API.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options => {
                options.UseSqlite(configuration.GetConnectionString("IdentityConnection"));
            });

            return services;
        }
    }
}