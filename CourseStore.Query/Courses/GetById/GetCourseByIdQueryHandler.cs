using CourseStore.Domain.CourseAgg.Repository;
using CourseStore.Query.Courses.DTOs;
using CourseStore.Query.Courses.Mapper;
using CourseStore.Query.Shared.Repository;
using MediatR;

namespace CourseStore.Query.Courses.GetById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseReadModel>
    {
        private readonly IGenericRepository<CourseReadModel> _courseRepository;

        public GetCourseByIdQueryHandler(IGenericRepository<CourseReadModel> courseRepository)
        {
            this._courseRepository=courseRepository;
        }
        public async Task<CourseReadModel> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _courseRepository.GetByIdAsync(request.Id);
            return res;
        }
    }

}
