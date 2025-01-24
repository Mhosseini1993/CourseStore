using CourseStore.Domain.Shared;

namespace CourseStore.Domain.CourseAgg.Events
{
    public class CourseRemoved : BaseDomainEvent
    {
        public int CourseId { get; private set; }
        public CourseRemoved(int courseId)
        {
            CourseId=courseId;
        }
    }
}
