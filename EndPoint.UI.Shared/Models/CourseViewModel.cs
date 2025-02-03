using CourseStore.Domain.CourseAgg.Enum;

namespace EndPoint.UI.Shared.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Level Level { get; set; }
    }
}
