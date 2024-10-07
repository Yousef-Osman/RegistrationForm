using AutoMapper;
using MediatR;
using RegistrationForm.Application.Common.DTOs;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Queries.Governates.GetAll;
internal class GetAllGovernatesQueryHandler : IRequestHandler<GetAllGovernatesQuery, IReadOnlyList<GovernateDto>>
{
    private readonly IReadRepository<Governate, long> _governateRepo;
    private readonly IMapper _mapper;

    public GetAllGovernatesQueryHandler(IReadRepository<Governate, long> governateRepo, IMapper mapper)
    {
        _governateRepo = governateRepo;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GovernateDto>> Handle(GetAllGovernatesQuery request, CancellationToken cancellationToken)
    {
        var governates = await _governateRepo.GetListAsync();

        return _mapper.Map<IReadOnlyList<GovernateDto>>(governates);
    }
}