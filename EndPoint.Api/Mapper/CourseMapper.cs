using AutoMapper;
using CourseStore.Query.Courses.DTOs;
using EndPoint.Api.ViewModels.Course;
using Microsoft.EntityFrameworkCore;

namespace EndPoint.Api.Mapper
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<CourseReadModel, CourseViewModel>()
                .ReverseMap();
        }
    }
}
