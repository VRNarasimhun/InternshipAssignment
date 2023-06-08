using InternUserManagement.Models.DTO;

namespace JWTAuthenticationExample.Interfaces
{
    public interface IGenerateToken 
    {
        public string GenerateToken(UserDTO user);
    }
}
