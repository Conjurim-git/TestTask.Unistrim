using TestTask.Unistrim.Api.Models;

namespace TestTask.Unistrim.Api.Dto;

public record UserDiscount
{
    //статический метод преобразования FromModel - это пример проектирования Маппер
    public static UserDiscount FromModel(DiscountPropertiesModel model)
    {
        return new UserDiscount
        {
            Id = model.Id,
            IsDiscount = model.IsDiscount,
            ValueOfDiscount = model.ValueOfDiscount
        };
    }

    public required Guid Id { get; init; }
    public required bool IsDiscount { get; init; }
    public required decimal ValueOfDiscount { get; init; }
}

