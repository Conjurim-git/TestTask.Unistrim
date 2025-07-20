using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces;

public interface IUserDiscountService
{
    Task<List<Guid>> ChooseIDsForDiscountAsync();
}

