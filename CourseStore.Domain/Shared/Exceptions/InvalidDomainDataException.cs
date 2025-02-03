namespace CourseStore.Domain.Shared.Exceptions
{
    public class InvalidDomainDataException:BaseDomainException
    {
        public InvalidDomainDataException() : base() { }

        public InvalidDomainDataException(string message) : base(message) { }

    }
}
