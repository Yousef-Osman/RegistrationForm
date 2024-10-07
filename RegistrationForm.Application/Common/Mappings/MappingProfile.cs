using AutoMapper;
using RegistrationForm.Application.Common.DTOs;
using RegistrationForm.Domain.Entities;

namespace RegistrationForm.Application.Common.Mappings;
internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, UserDto>().ReverseMap();
        CreateMap<CreateAddressDto, Address>();
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Governate, GovernateDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
    }
}