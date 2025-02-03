using CourseStore.Domain.Shared.Exceptions;

namespace CourseStore.Domain.UserAgg.ValueObject
{
    public class PhoneNumber
    {
        public string Number { get; private set; }
        public PhoneNumber(string number)
        {
            NullOrEmptyDomainDataException.CheckIfNull(number, "PhoneNumber");
            Number=number;
        }

    }
}
