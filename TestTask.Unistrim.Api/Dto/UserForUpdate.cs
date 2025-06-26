namespace TestTask.Unistrim.Api.Dto
{
    public record UserForUpdate
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
