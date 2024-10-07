namespace RegistrationForm.Application.Common.DTOs;
public class AddressDto
{
    public long Id { get; set; }
    public string? Governate { get; set; }
    public string? City { get; set; }
    public int Street { get; set; }
    public int BuildingNumber { get; set; }
    public int FlatNumber { get; set; }
}
