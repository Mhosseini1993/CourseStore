using CourseStore.Query.Courses.DTOs;
using MediatR;

namespace CourseStore.Query.Courses.GetList
{
    public class GetCourseListQuery : IRequest<List<CourseReadModel>>
    {
    }
}
