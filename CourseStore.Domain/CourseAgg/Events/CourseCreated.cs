using CourseStore.Domain.Shared;

namespace CourseStore.Domain.CourseAgg.Events
{
    public class CourseCreated : BaseDomainEvent
    {
        public int CourseId { get; private set; }
        public string AuthorName { get; private set; }
        public string AuthorPhoneNumber { get; private set; }

        public CourseCreated(int courseId, string authorName, string authorPhoneNumber)
        {
            CourseId=courseId;
            AuthorName=authorName;
            AuthorPhoneNumber=authorPhoneNumber;
        }
    }
}
