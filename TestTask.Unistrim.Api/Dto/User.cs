using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Unistrim.Api.Dto;

public record User
{

    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; } 
    public required string Email { get; init; } 
    public required string Password { get; init; }
}
