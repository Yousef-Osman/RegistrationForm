using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrationForm.Application.Interfaces.Persistence;
using RegistrationForm.Persistence.Data;
using RegistrationForm.Persistence.Repositories;

namespace RegistrationForm.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        string connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Default connection string not found.");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped(typeof(IReadRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
