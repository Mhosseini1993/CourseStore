using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Domain.CourseAgg.Repository;
using CourseStore.Query.Courses.DTOs;
using CourseStore.Query.Shared.Repository;
using MediatR;

namespace CourseStore.Query.Courses.EventHandlers
{
    public class CourseCreatedEventHandler : INotificationHandler<CourseCreated>
    {
        private readonly ICourseRepository _writeRepository;//SQl
        private readonly IGenericRepository<CourseReadModel> _readRepository;//MongoDb

        public CourseCreatedEventHandler(ICourseRepository courseRepository, IGenericRepository<CourseReadModel> genericRepository)
        {
            this._writeRepository=courseRepository;
            this._readRepository=genericRepository;
        }
        public async Task Handle(CourseCreated notification, CancellationToken cancellationToken)
        {
            var course = await _writeRepository.GetByIdAsync(notification.CourseId);
            await _readRepository.AddAsync(new CourseReadModel()
            {
                Id=course.Id,
                Name=course.Name,
                Author=course.Author,
                ReleaseDate=course.ReleaseDate,
                Description=course.Description,
                Level=course.Level
            });
        }
    }
}
