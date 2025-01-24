using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Domain.CourseAgg.Repository;
using MediatR;


namespace CourseStore.Application.Courses.EventHandlers
{
    public class CourseCreatedEventHandler : INotificationHandler<CourseCreated>
    {
        private readonly ICourseRepository _courseRepository;

        public CourseCreatedEventHandler(ICourseRepository courseRepository)
        {
            this._courseRepository=courseRepository;
        }
        public async Task Handle(CourseCreated notification, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(notification.CourseId);

        }
    }
}
