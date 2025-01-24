using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Query.Courses.DTOs;
using CourseStore.Query.Shared.Repository;
using MediatR;

namespace CourseStore.Query.Courses.EventHandlers
{
    public class CourseRemovedEventHandler : INotificationHandler<CourseRemoved>
    {
        private readonly IGenericRepository<CourseReadModel> _readRepository;//MongoDb
        public CourseRemovedEventHandler(IGenericRepository<CourseReadModel> genericRepository)
        {
            this._readRepository=genericRepository;
        }
        public async Task Handle(CourseRemoved notification, CancellationToken cancellationToken)
        {
            await _readRepository.DeleteAsync(notification.CourseId);
        }
    }
}
