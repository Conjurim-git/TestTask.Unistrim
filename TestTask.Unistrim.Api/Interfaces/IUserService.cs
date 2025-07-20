using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<IReadOnlyCollection<User>> GetAllUsers();
        Task<IReadOnlyCollection<Guid>> GetUserIDsAsync();
        Task ChangeUserById(UserForUpdate user);
        Task DeleteUserById(Guid id);
    }
}
