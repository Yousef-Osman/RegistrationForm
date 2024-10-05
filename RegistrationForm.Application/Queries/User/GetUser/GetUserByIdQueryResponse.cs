using RegistrationForm.Application.Common.DTOs;

namespace RegistrationForm.Application.Queries.User.GetUser;
public class GetUserByIdQueryResponse
{
    public bool IsSuccess { get; set; }
    public UserDto? User { get; set; }
};