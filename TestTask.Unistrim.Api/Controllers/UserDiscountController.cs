using Microsoft.AspNetCore.Mvc;
using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Interfaces;

namespace TestTask.Unistrim.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDiscountController : ControllerBase
{
    private readonly ILogger<UserDiscountController> _logger;
    private readonly IUserDiscountService _userService;

    public UserDiscountController(
        ILogger<UserDiscountController> logger, IUserDiscountService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    [Route("CreateUserDiscount")]

    public async Task<ActionResult<List<UserDiscount>>> CreateUserDiscount()
    {
        try
        {
            _logger.LogInformation("Создание скидок, для пользователей с рандомным id");
            var result = await _userService.CreateListUserDiscountAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Произошла ошибка при добавлении нового пользователя: {ex}", ex.Message);

            return BadRequest(ex.Message);
        }
    }
}
