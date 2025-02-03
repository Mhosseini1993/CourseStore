using CourseStore.Domain.CourseAgg.Enum;
using EndPoint.Api.ViewModels.Shared;

namespace EndPoint.Api.ViewModels.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Level Level { get; set; }
        public List<LinkDto> LinkDtos { get; set; } = new List<LinkDto>();
    }
}
