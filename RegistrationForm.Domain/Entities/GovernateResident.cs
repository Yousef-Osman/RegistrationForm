using RegistrationForm.Domain.Common;

namespace RegistrationForm.Domain.Entities;
public class GovernateResident : BaseEntity<long>
{
    public long GovernateId { get; set; }
    public int Count { get; set; }
    public Governate? Governate { get; set; }
}
