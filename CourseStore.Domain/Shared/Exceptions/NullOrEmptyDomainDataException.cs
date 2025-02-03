namespace CourseStore.Domain.Shared.Exceptions
{
    public class NullOrEmptyDomainDataException : BaseDomainException
    {
        public NullOrEmptyDomainDataException() : base() { }

        public NullOrEmptyDomainDataException(string message) : base(message) { }

        public static void CheckIfNull(string value,string nameOfField)
        {
            if (string.IsNullOrEmpty(value))
                throw new NullOrEmptyDomainDataException($"{nameOfField} is empty");
        }
    }
}
