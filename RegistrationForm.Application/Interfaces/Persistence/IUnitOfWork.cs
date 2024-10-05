namespace RegistrationForm.Application.Interfaces.Persistence;
public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
}