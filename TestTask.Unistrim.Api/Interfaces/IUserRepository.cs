using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces;

    public interface IUserRepository
    {
        Task<UserModel> CreateAsync(User user);
        Task<List<User>> GetUsersAsync();
        Task DeleteUserAsync(Guid id);
        Task<UserModel> ChangeUserAsync(Guid id, string newFirstName, string newLastName, string newEmail, string newPassword);
    }

