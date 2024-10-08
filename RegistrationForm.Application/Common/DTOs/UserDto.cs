﻿namespace RegistrationForm.Application.Common.DTOs;
public class UserDto
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public required string MobileNumber { get; set; }
    public required string Email { get; set; }

    public IEnumerable<CreateAddressDto>? Addresses { get; set; }
}
