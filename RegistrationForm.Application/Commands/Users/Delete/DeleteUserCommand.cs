using MediatR;

namespace RegistrationForm.Application.Commands.Users.Delete;
public class DeleteUserCommand : IRequest<bool>
{
    public long Id { get; set; }
}
