using MediatR;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Commands.Users.Update;
internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IRepository<AppUser, long> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IRepository<AppUser, long> userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(request.Id);

        if (user == null)
            return false;

        user.FirstName = request.FirstName;
        user.MiddleName = request.MiddleName;
        user.LastName = request.LastName;
        user.BirthDate = request.BirthDate;
        user.MobileNumber = request.MobileNumber;
        user.Email = request.Email;

        _userRepository.Update(user);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
