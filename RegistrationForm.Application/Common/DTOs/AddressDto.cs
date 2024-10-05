namespace RegistrationForm.Application.Common.DTOs;
internal class AddressDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long GovernateId { get; set; }
    public long CityId { get; set; }
    public int Street { get; set; }
    public int BuildingNumber { get; set; }
    public int FlatNumber { get; set; }
}
