using RegistrationForm.Application;
using RegistrationForm.Infrastructure;
using RegistrationForm.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services
       .AddApplication()
       .AddInfrastructure(builder.Configuration);

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

    await DataSeeder.SeedAsync(app.Services);

    app.UseHttpsRedirection();

    app.UseCors("CorsPolicy");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
