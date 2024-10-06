using MediatR;

namespace RegistrationForm.Application.Commands.User.Create;
public class CreateUserCommand: IRequest<bool>
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public required string MobileNumber { get; set; }
    public required string Email { get; set; }
}
