using Microsoft.EntityFrameworkCore;
using RelationshipWebsiteV2.Models;
using RelationshipWebsiteV2.Shared;

namespace RelationshipWebsiteV2.Services
{
    public class UserService : IUserService
    {
        private readonly RelationshipDBContext dbContext;
        public UserService(RelationshipDBContext relationshipDBContext)
        {

            this.dbContext = relationshipDBContext;
        }
        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            this.dbContext.Remove(user);
            await this.dbContext.SaveChangesAsync();

        }
        private async Task<bool> UsernameExistsAsync(string username)
        {
            return await this.dbContext.Users.AnyAsync(u =>  u.Username == username);
        }
        private async Task<bool> EmailExistsAsync(string email)
        {
            return await this.dbContext.Users.AnyAsync(u => u.Email == email);

        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await this.dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            var user = await this.dbContext.Users.SingleOrDefaultAsync(u => u.UserId == id);
            return user;
        }
        public async Task<OperationResult> LoginAsync(LoginModel loginModel)
        {
            //check if email exists.
            //if it exists, hash the password and see if matches the db one.
            
            var user_by_email = await GetByEmailAsync(loginModel.Email);
            if (user_by_email is null) return new OperationResult(false, "This email wasn't registered.");
            
            var existing_hash = user_by_email.PasswordHash;
            var current_hash = HashPasswordService.HashPassword(loginModel.Password);

            if (!HashPasswordService.CompareHashes(existing_hash, current_hash)) return new OperationResult(false, "Password doesn't match.");

            return new OperationResult(true, "Login successful!");

           
           
        }

        public async Task<OperationResult> RegisterAsync(RegisterModel registerModel)
        {

            //check if username and email
            var username_exists = this.UsernameExistsAsync(registerModel.Username);
            var email_exists = this.EmailExistsAsync(registerModel.Email);
            await Task.WhenAll(username_exists, email_exists);
            var res1 = username_exists.Result; var res2 = email_exists.Result;
            if (res1 || res2) 
            {
                if (res1) return new OperationResult(success: false, message: "Username already exists.");
                if (res2) return new OperationResult(success: false, message: "Email already exists");
            }
            //done checking and its ok
            

            
            //make user based on registerModel
            //add it to db
            var user_to_add = new User
            {

                Username = registerModel.Username,
                Email = registerModel.Email,
                PasswordHash = HashPasswordService.HashPassword(registerModel.Password),
                DateOfBirth = registerModel.Birthdate,
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)
            };
            try
            {
                await this.dbContext.Users.AddAsync(user_to_add);
                await this.dbContext.SaveChangesAsync();
                return new OperationResult(true, "Registered successfully!");
            }
            catch (Exception ex)
            {
                return new OperationResult(false, ex.Message);
            }
        }
    }
}
