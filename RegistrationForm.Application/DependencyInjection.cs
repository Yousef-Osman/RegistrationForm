using Microsoft.Extensions.DependencyInjection;
using RegistrationForm.Application.Common.Mappings;
using System.Reflection;

namespace RegistrationForm.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
