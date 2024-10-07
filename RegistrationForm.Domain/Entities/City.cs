using RegistrationForm.Domain.Common;

namespace RegistrationForm.Domain.Entities;
public class City : BaseEntity<long>
{
    public required string Name { get; set; }
    public long GovernateId { get; set; }
    public Governate? Governate { get; set; }
}
