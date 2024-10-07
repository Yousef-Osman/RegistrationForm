using Microsoft.EntityFrameworkCore;
using RegistrationForm.Application;
using RegistrationForm.Infrastructure;
using RegistrationForm.Persistence;
using RegistrationForm.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
       .AddApplication()
       .AddInfrastructure()
       .AddPersistence(builder.Configuration);

    var clientUrl = builder.Configuration.GetSection("ClientUrl").Value ?? string.Empty;

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder.WithOrigins(clientUrl)
                              .AllowAnyMethod()
                              .AllowAnyHeader());
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    var logger = services.GetRequiredService<ILogger<Program>>();
    try
    {
        await context.Database.MigrateAsync();
        await DataSeeder.SeedAsync(context);
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occured during migration");
    }

    app.UseHttpsRedirection();

    app.UseCors("CorsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
