namespace TestTask.Unistrim.Api.Dto
{
    public class UsersWithDiscounts
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required bool IsDiscount { get; init; }
        public required decimal ValueOfDiscount { get; init; }
    }
}
