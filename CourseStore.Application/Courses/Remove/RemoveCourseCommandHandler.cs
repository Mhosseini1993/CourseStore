using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Domain.CourseAgg.Repository;
using MediatR;

namespace CourseStore.Application.Courses.Remove
{
    public class RemoveCourseCommandHandler : IRequestHandler<RemoveCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediator _mediator;

        public RemoveCourseCommandHandler(ICourseRepository courseRepository, IMediator mediator)
        {
            this._courseRepository=courseRepository;
            this._mediator=mediator;
        }

        public async Task<Unit> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            await _courseRepository.DeleteAsync(request.id);
            await _mediator.Publish(new CourseRemoved(request.id));
            return await Unit.Task;
        }
    }

}
