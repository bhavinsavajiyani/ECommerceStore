using System.Security.Claims;
using EComm_Store_Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EComm_Store_API.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindUserByClaimsPrincipalWithAddressAsync(
            this UserManager<AppUser> userManager,
            ClaimsPrincipal user)
            {
                var email = user.FindFirstValue(ClaimTypes.Email);

                return await userManager.Users.Include(u => u.Address)
                    .SingleOrDefaultAsync(u => u.Email == email);
            }

        public static async Task<AppUser> FindUserByEmailFromClaimsPrincipal(
            this UserManager<AppUser> userManager,
            ClaimsPrincipal user)
            {
                return await userManager.Users
                    .SingleOrDefaultAsync(u => u.Email == user.FindFirstValue(ClaimTypes.Email));
            }
    }
}