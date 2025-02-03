using CourseStore.Query.Users.DTOs;
using MediatR;

namespace CourseStore.Query.Users.GetByPhoneNumber
{
    public record GetUserByPhoneNumberQuery(string phoneNumber) : IRequest<UserReadModel>
    {
    }
}
