namespace TestTask.Unistrim.Api.Models
{
    public sealed class DiscountPropertiesModel
    {
        public Guid     Id { get; init; }
        public bool     IsDiscount { get; init; }
        public decimal  ValueOfDiscount { get; init; }
    }
}
