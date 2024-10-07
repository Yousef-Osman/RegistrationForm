using MediatR;
using RegistrationForm.Application.Common.DTOs;

namespace RegistrationForm.Application.Queries.Governates.GetAll;
public class GetAllGovernatesQuery : IRequest<IReadOnlyList<GovernateDto>>
{
}
