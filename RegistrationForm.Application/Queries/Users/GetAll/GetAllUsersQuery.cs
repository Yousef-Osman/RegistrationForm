using MediatR;
using RegistrationForm.Application.Common.DTOs;

namespace RegistrationForm.Application.Queries.Users.GetAll;
public class GetAllUsersQuery: IRequest<IReadOnlyList<UserDto>>
{
}
