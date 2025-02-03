using CourseStore.Domain.UserAgg.ValueObject;
using MediatR;

namespace CourseStore.Application.Users.Register
{
    public class RegisterUserCommand : IRequest
    {
        public PhoneNumber PhoneNumber { get; private set; }
        public RegisterUserCommand(PhoneNumber phoneNumber)
        {
            PhoneNumber=phoneNumber;
        }
    }
}
