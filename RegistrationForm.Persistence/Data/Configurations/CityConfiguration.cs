using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Persistence.Data.Configurations;
internal class CityConfiguration : IEntityTypeConfiguration<City>
{
    void IEntityTypeConfiguration<City>.Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(100);
    }
}
