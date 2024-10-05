using RegistrationForm.Domain.Common;

namespace RegistrationForm.Domain.Entities;
public class Governate: BaseEntity<long>
{
    public required string Name { get; set; }
}
