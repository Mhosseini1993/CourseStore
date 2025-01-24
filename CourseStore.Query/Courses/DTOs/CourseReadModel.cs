using CourseStore.Domain.CourseAgg.Enum;
using CourseStore.Query.Shared;

namespace CourseStore.Query.Courses.DTOs
{
    public class CourseReadModel : BaseReadModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Level Level { get; set; }
    }
}
