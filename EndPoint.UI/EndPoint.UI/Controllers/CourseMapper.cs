using CourseStore.Query.Courses.DTOs;
using EndPoint.UI.Shared.Models;

namespace EndPoint.UI.Controllers
{
    public class CourseMapper
    {
        public static CourseViewModel MapCourseReadModelToCourseViewModel(CourseReadModel course)
        {
            return new CourseViewModel()
            {
                Id= course.Id,
                Name= course.Name,
                Author= course.Author,
                Description= course.Description,
                Level= course.Level,
                ReleaseDate= course.ReleaseDate,
            };
        }

    }
}
