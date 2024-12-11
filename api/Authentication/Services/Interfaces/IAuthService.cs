using api.Authentication.Models;

namespace api.Authentication.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);

        Task<bool> VerifyUserCredentials(string username, string password);
    }
}