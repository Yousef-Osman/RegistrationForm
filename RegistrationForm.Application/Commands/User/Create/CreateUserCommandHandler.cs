using MediatR;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Commands.User.Create;
internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    private readonly IRepository<AppUser, long> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IRepository<AppUser, long> userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
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
        };

        _userRepository.Add(user);
        await _unitOfWork.SaveChangesAsync();

        return true ;
    }
}
