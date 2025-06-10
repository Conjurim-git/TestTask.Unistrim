namespace TestTask.Unistrim.Api.Models
{
    public sealed class UserModel
    {
        public Guid Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }
    }
}
