using MediatR;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Commands.User.Delete;
internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IRepository<AppUser, long> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserCommandHandler(IRepository<AppUser, long> userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindAsync(request.Id);

        if (user == null)
            return false;

        _userRepository.Delete(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
