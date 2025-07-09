using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces;

    public interface IUserRepository
    {
        Task<UserModel> CreateAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task<List<Guid>> GetIDsAsync();
        Task<List<UserDiscount>> GetUsersToDiscountAsync();
        Task DeleteUserAsync(Guid id);
        Task<UserModel> ChangeUserAsync(UserForUpdate user);
        
    }

