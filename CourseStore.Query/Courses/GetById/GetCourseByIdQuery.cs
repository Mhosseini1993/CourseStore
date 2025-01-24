using CourseStore.Query.Courses.DTOs;
using MediatR;

namespace CourseStore.Query.Courses.GetById
{
    public record GetCourseByIdQuery(int Id) : IRequest<CourseReadModel>
    {
    }

}
