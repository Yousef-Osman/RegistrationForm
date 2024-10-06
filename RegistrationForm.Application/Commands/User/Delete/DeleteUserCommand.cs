using MediatR;

namespace RegistrationForm.Application.Commands.User.Delete;
public class DeleteUserCommand : IRequest<bool>
{
    public long Id { get; set; }
}
