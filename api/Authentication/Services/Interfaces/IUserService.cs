using api.Authentication.Models;
using api.Authentication.Models.DTOs;

namespace api.Authentication.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Create(RegisterRequest request);

        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        Task<bool> Delete(int id);

        Task<bool> Exists(int id);

        Task<ICollection<UserDTO>> GetAll();

        Task<UserDTO> GetById(int id);

        Task<User> GetByUsername(string username);

        Task<UserDTO> Update(UserDTO user);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}