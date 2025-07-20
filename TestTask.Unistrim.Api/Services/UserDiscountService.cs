using System.Collections.Generic;
using System.Net;
using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Interfaces;
using TestTask.Unistrim.Api.Models;


namespace TestTask.Unistrim.Api.Services;

public class UserDiscountService: IUserDiscountService
{
    private readonly ILogger<UserDiscountService> _loggerDiscount;
    private readonly IUserDiscountRepository _repositoryDiscount;
    private readonly ILogger<UserService> _loggerUser;
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;


    public UserDiscountService(
        ILogger<UserDiscountService> loggerDiscount,
        ILogger<UserService> loggerUser,
        IUserDiscountRepository repositoryDiscount,
        IUserService userService,
        IUserRepository userRepository)
    {
        _loggerDiscount = loggerDiscount;
        _loggerUser = loggerUser;    //Зачем нам нужен логгер? IDE подчеркивает как неиспользуемый элемент
        _repositoryDiscount = repositoryDiscount;
        _userService = userService;
        _userRepository = userRepository;
    }

    public async Task<IReadOnlyCollection<Guid>> QueryUserIDsAsync()
    {
        var ids = await _userService.GetUserIDsAsync();
        return ids;
    }

    public async Task<List<Guid>> ChooseIDsForDiscountAsync()
    {
        var random = new Random();
        int countUsersWithDiscount = 3;
        var ids = await QueryUserIDsAsync();

        List<Guid> IDsWithDiscount;
        IDsWithDiscount = ids.OrderBy(x => random.NextDouble()).Take(countUsersWithDiscount).ToList();

        return IDsWithDiscount;
    }

    public async Task<List<UserDiscount>> CreateListUserDiscountAsync()
    {
        List<Guid> ids = await ChooseIDsForDiscountAsync();
        List<UserDiscount> usersWithDiscounts = await _repositoryDiscount.CreateDiscountByListAsync(ids);

        return usersWithDiscounts;
    }
}

