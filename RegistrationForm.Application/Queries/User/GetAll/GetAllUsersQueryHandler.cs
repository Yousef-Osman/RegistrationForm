using AutoMapper;
using MediatR;
using RegistrationForm.Application.Common.DTOs;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Queries.User.GetAll;
internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IReadOnlyList<UserDto>>
{
    private readonly IReadRepository<AppUser, long> _userRepo;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IReadRepository<AppUser, long> userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepo.GetListAsync();

        return _mapper.Map<IReadOnlyList<UserDto>>(users);
    }
}
