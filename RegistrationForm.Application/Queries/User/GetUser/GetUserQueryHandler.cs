using AutoMapper;
using MediatR;
using RegistrationForm.Application.Common.DTOs;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Queries.User.GetUser;
internal class GetUserQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
{
    private readonly IReadRepository<AppUser, long> _userRepo;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IReadRepository<AppUser, long> userRepo, IMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }

    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepo.FirstOrDefaultAsync(x => x.Id == request.Id);

        return new GetUserByIdQueryResponse 
        { 
            IsSuccess= true,
            User = _mapper.Map<UserDto>(user)
        };
    }
}