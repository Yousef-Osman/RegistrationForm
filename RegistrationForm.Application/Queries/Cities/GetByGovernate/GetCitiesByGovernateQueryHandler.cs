using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RegistrationForm.Application.Common.DTOs;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Queries.Cities.GetByGovernate;
internal class GetCitiesByGovernateQueryHandler : IRequestHandler<GetCitiesByGovernateQuery, IReadOnlyList<CityDto>>
{
    private readonly IReadRepository<City, long> _cityRepo;
    private readonly IMapper _mapper;

    public GetCitiesByGovernateQueryHandler(IReadRepository<City, long> cityRepo, IMapper mapper)
    {
        _cityRepo = cityRepo;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CityDto>> Handle(GetCitiesByGovernateQuery request, CancellationToken cancellationToken)
    {
        var cities = await _cityRepo.GetQuery()
            .Where(x=>x.GovernateId == request.Id)
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IReadOnlyList<CityDto>>(cities);
    }
}
