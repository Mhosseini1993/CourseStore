using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Domain.CourseAgg.Repository;
using CourseStore.Query.Courses.DTOs;
using CourseStore.Query.Shared.Repository;
using MediatR;

namespace CourseStore.Query.Courses.EventHandlers
{
    public class CourseEditedEventHandler : INotificationHandler<CourseEdited>
    {
        private readonly ICourseRepository _writeRepository;//SQl
        private readonly IGenericRepository<CourseReadModel> _readRepository;//MongoDb

        public CourseEditedEventHandler(ICourseRepository courseRepository, IGenericRepository<CourseReadModel> genericRepository)
        {
            this._writeRepository=courseRepository;
            this._readRepository=genericRepository;
        }
        public async Task Handle(CourseEdited notification, CancellationToken cancellationToken)
        {
            var course = await _writeRepository.GetByIdAsync(notification.CourseId);
            await _readRepository.UpdateAsync(new CourseReadModel()
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
