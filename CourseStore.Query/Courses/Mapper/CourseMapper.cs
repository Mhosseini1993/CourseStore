using CourseStore.Domain.CourseAgg;
using CourseStore.Query.Courses.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Query.Courses.Mapper
{
    public class CourseMapper
    {
        public static CourseReadModel MapCourseToCourseDto(Course course)
        {
            return new CourseReadModel()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Author = course.Author,
                ReleaseDate = course.ReleaseDate,
                Level = course.Level,
            };


        }
    }
}
