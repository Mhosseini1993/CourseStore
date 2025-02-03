using CourseStore.Domain.Shared;
using CourseStore.Domain.Shared.Exceptions;
using CourseStore.Domain.UserAgg.Events;
using CourseStore.Domain.UserAgg.ValueObject;

namespace CourseStore.Domain.UserAgg
{
    public class User : BaseAggregate
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        private User()
        {
            
        }
        public User(string firstName, string lastName, PhoneNumber phoneNumber)
        {
            NullOrEmptyDomainDataException.CheckIfNull(firstName, nameof(firstName));
            NullOrEmptyDomainDataException.CheckIfNull(lastName, nameof(lastName));

            FirstName=firstName;
            LastName=lastName;
            PhoneNumber=phoneNumber;

           // AddDomainEvent(new UserRegistered(Id, PhoneNumber.Number));
        }
        public void Edit(string firstName, string lastName, PhoneNumber phoneNumber)
        {
            NullOrEmptyDomainDataException.CheckIfNull(firstName, nameof(firstName));
            NullOrEmptyDomainDataException.CheckIfNull(lastName, nameof(lastName));

            FirstName=firstName;
            LastName=lastName;
            PhoneNumber=phoneNumber;
        }

        public static User Register(PhoneNumber phoneNumber)
        {
            User user = new User(" ", " ", phoneNumber);
            return user;
        }

    }
}
