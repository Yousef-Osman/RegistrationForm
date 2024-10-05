using RegistrationForm.Domain.Common;

namespace RegistrationForm.Domain.Entities;
public class AppUser: BaseEntity<long>
{
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public required string MobileNumber { get; set; }
    public required string Email { get; set; }

    IEnumerable<Address>? Addresses { get; set;}
}
