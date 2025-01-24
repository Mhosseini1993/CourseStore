using CourseStore.Domain.Shared;

namespace CourseStore.Domain.CourseAgg.Events
{
    public class CourseEdited : BaseDomainEvent
    {
        public int CourseId { get; private set; }
        public CourseEdited(int courseId)
        {
            CourseId=courseId;
        }
    }
}
