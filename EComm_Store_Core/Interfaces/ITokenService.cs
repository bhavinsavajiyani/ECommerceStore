using EComm_Store_Core.Entities.Identity;

namespace EComm_Store_Core.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(AppUser user);
    }
}