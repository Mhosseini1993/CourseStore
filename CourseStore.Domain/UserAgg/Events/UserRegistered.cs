using CourseStore.Domain.Shared;

namespace CourseStore.Domain.UserAgg.Events
{
    public class UserRegistered : BaseDomainEvent
    {
        public int UserId { get; private set; }
        public string PhoneNumber { get; private set; }

        public UserRegistered(int userId, string phoneNumber)
        {
            UserId=userId;
            PhoneNumber=phoneNumber;
        }
    }
}
