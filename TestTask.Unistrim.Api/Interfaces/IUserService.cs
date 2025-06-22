using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<IReadOnlyCollection<User>> GetAllUsers();
        Task ChangeUserById(Guid id, string FirstName, string LastName, string Email, string Password);
        Task DeleteUserById(Guid id);
    }
}
