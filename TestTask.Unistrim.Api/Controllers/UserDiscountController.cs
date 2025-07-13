using Microsoft.AspNetCore.Mvc;
using TestTask.Unistrim.Api.Interfaces;

namespace TestTask.Unistrim.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDiscountController : ControllerBase
{
    private readonly ILogger<UserDiscountController> _logger;
    private readonly IUserService _userService;

    public UserDiscountController(
        ILogger<UserDiscountController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
}
