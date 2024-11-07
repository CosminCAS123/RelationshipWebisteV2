using RelationshipWebsiteV2.Models;
using RelationshipWebsiteV2.Shared;

namespace RelationshipWebsiteV2.Services
{
    public interface IUserService
    {
        Task<OperationResult> RegisterAsync(RegisterModel registerModel);
        Task<OperationResult> LoginAsync(LoginModel loginModel);
       

        Task DeleteAsync(int id);
    

        Task<User> GetByIdAsync(int id);

    }
}
