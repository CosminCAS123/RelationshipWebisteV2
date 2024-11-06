using RelationshipWebsiteV2.Models;
using RelationshipWebsiteV2.Shared;

namespace RelationshipWebsiteV2.Services
{
    public interface IUserService
    {
        Task<OperationResult> RegisterAsync(RegisterModel registerModel);
        Task<OperationResult> LoginAsync(LoginModel loginModel);
        Task<User?> GetByEmailAsync(string email);

        Task DeleteAsync(int id);
        Task<bool> EmailExistsAsync(string email);

        Task<User> GetByIdAsync(int id);

    }
}
