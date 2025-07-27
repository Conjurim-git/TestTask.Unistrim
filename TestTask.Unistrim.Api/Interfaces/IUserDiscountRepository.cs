using TestTask.Unistrim.Api.Dto;
using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Interfaces;

public interface IUserDiscountRepository
{
    Task<List<DiscountPropertiesModel>> CreateDiscountByListAsync(List<Guid> discountIds);
    Task<DiscountPropertiesModel> CreateDiscountByIdAsync(Guid discountId);
}

