using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Persistence.Data.Configurations;
internal class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    void IEntityTypeConfiguration<Address>.Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.Street)
            .HasMaxLength(200);

        builder.Property(x => x.BuildingNumber)
            .HasMaxLength(200);
    }
}
