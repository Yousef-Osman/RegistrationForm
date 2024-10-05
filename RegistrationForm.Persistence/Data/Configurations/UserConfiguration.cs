using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Persistence.Data.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    void IEntityTypeConfiguration<AppUser>.Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(20);

        builder.Property(x => x.MiddleName)
            .HasMaxLength(40);

        builder.Property(x => x.LastName)
            .HasMaxLength(20);

        builder.Property(x => x.MobileNumber)
            .HasMaxLength(40);

        builder.Property(x => x.Email)
        .HasMaxLength(200);
    }
}