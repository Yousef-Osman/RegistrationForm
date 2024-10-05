using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Persistence.Data.Configurations;
internal class GovernateConfiguration : IEntityTypeConfiguration<Governate>
{
    void IEntityTypeConfiguration<Governate>.Configure(EntityTypeBuilder<Governate> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(100);
    }
}
