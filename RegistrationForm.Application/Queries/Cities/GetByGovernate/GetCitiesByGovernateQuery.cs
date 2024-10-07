using MediatR;
using RegistrationForm.Application.Common.DTOs;

namespace RegistrationForm.Application.Queries.Cities.GetByGovernate;
public class GetCitiesByGovernateQuery : IRequest<IReadOnlyList<CityDto>>
{
    public long Id { get; set; }
}
