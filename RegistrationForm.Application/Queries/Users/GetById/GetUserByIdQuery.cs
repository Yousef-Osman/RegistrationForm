using MediatR;
using RegistrationForm.Application.Common.DTOs;

namespace RegistrationForm.Application.Queries.Users.GetById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public long Id { get; set; }
}