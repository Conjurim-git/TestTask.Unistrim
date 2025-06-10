using Microsoft.AspNetCore.Mvc;
using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Interfaces;
using TestTask.Unistrim.Api.Services;

namespace TestTask.Unistrim.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(
        ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    [Route("CreateUser")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            _logger.LogInformation("Создание пользователя с id: {id}", user.Id);
            var result = await _userService.CreateUser(user);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Произошла ошибка при добавлении нового пользователя: {ex}", ex.Message);

            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("AllUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpDelete]
    [Route("DeleteUser")]
    public async Task<ActionResult<User>> DeleteUser(Guid id)
    {
        try
        {
            string result = await _userService.DeleteUserById(id);

            return Ok(result);
        }

        catch (Exception ex)
        {
            _logger.LogError("Произошла ошибка при удалении пользователя с {id}: {ex}", id, ex.Message);

            return BadRequest(ex.Message);
        }
    }
}
