namespace CourseStore.Domain.Shared.Exceptions
{
    public class BaseDomainException : Exception
    {
        public BaseDomainException() : base() { }

        public BaseDomainException(string message) : base(message) { }

    }
}
