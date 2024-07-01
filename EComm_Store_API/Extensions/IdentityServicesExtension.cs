using EComm_Store_Core.Entities.Identity;
using EComm_Store_Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
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

            services.AddIdentityCore<AppUser>(options => {
                // Add identity options for custom requirements
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }
    }
}