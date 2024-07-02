using Microsoft.AspNetCore.Identity;

namespace EComm_Store_Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}