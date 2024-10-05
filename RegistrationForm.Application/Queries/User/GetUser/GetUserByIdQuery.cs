using MediatR;

namespace RegistrationForm.Application.Queries.User.GetUser;

public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
{
    public long Id { get; set; }
}