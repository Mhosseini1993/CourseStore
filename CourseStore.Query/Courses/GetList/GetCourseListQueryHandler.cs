using CourseStore.Domain.CourseAgg.Repository;
using CourseStore.Query.Courses.DTOs;
using CourseStore.Query.Courses.Mapper;
using CourseStore.Query.Shared.Repository;
using MediatR;

namespace CourseStore.Query.Courses.GetList
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, List<CourseReadModel>>
    {
        private readonly IGenericRepository<CourseReadModel> _courseRepository;

        public GetCourseListQueryHandler(IGenericRepository<CourseReadModel> courseRepository)
        {
            this._courseRepository=courseRepository;
        }
        public async Task<List<CourseReadModel>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.GetAllAsync();
            return res;
        }
    }
}
