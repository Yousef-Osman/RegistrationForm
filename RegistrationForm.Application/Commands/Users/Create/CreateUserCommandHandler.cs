using AutoMapper;
using MediatR;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Commands.Users.Create;
internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IRepository<AppUser, long> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IRepository<AppUser, long> userRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            MobileNumber = request.MobileNumber,
            Email = request.Email,
            Addresses = _mapper.Map<IEnumerable<Address>>(request.Addresses)
        };

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();

        return true ;
    }
}
