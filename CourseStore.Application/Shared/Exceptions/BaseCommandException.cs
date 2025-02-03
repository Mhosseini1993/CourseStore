namespace CourseStore.Application.Shared.Exceptions
{
    public class BaseCommandException : Exception
    {
        public BaseCommandException() : base()
        {

        }
        public BaseCommandException(string message) : base(message)
        {

        }
    }
}
