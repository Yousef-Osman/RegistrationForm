namespace RegistrationForm.Application.Common.DTOs;
public class CreateAddressDto
{
    public long CityId { get; set; }
    public required string Street { get; set; }
    public required string BuildingNumber { get; set; }
    public int FlatNumber { get; set; }
}
