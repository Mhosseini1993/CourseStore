namespace CourseStore.Application.Shared.Exceptions
{
    public class InvalidCommandException : BaseCommandException
    {
        public InvalidCommandException() : base()
        {

        }
        public InvalidCommandException(string message) : base(message)
        {

        }
    }
}
