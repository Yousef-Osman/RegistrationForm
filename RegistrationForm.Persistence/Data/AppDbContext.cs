using Microsoft.EntityFrameworkCore;
using RegistrationForm.Domain.Entities;
using RegistrationForm.Persistence.Data.Configurations;

namespace RegistrationForm.Persistence.Data;
public class AppDbContext: DbContext
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Governate> Governates { get; set; }
    public DbSet<City> Cities { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
    }
}
