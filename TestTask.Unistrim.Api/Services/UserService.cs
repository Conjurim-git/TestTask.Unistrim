using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Interfaces;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Services;

public class UserService: IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _repository;

    public UserService(
        ILogger<UserService> logger, 
        IUserRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<User> CreateUser(User user)
    {
        try
        {
            UserModel newUserModel = await _repository.CreateAsync(user);

            return new()
            {
                Id = newUserModel.Id,
                Email = newUserModel.Email,
                FirstName = newUserModel.FirstName,
                LastName = newUserModel.LastName,
                Password = newUserModel.Password,
            };
        }
        catch (Exception ex)
        {
            throw new Exception($"Произошла ошибка при добавлении нового пользователя {ex.Message}");
        }
    }
    public async Task<IReadOnlyCollection<User>> GetAllUsers()
    {
        return await _repository.GetUsersAsync();
    }

    public async Task ChangeUserById(UserForUpdate user)
    {
        try
        {
            await _repository.ChangeUserAsync(user);
            return;
        }
        catch(Exception ex)
        {
            throw new Exception($"Произошла ошибка при изменении пользователя {ex.Message}");
        }
       
    }

    
    public async Task DeleteUserById(Guid id)
    {
        await _repository.DeleteUserAsync(id);
    }
}
