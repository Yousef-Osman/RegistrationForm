using MediatR;
using RegistrationForm.Application.Common.DTOs;

namespace RegistrationForm.Application.Queries.User.GetAll;
public class GetAllUsersQuery: IRequest<IReadOnlyList<UserDto>>
{
}
