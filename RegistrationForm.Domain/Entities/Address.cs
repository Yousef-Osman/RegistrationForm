using RegistrationForm.Domain.Common;

namespace RegistrationForm.Domain.Entities;
public class Address: BaseEntity<long>
{
    public long UserId { get; set; }
    public long CityId { get; set; }
    public required string Street { get; set; }
    public required string BuildingNumber { get; set; }
    public int FlatNumber { get; set; }

    public AppUser? User { get; set; }
    public City? City { get; set; }
}
