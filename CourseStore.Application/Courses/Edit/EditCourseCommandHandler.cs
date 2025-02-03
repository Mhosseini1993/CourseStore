using CourseStore.Domain.CourseAgg.Repository;
using MediatR;

namespace CourseStore.Application.Courses.Edit
{
    public class EditCourseCommandHandler : IRequestHandler<EditCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediator _mediator;

        public EditCourseCommandHandler(ICourseRepository courseRepository, IMediator mediator)
        {
            this._courseRepository=courseRepository;
            this._mediator=mediator;
        }

        public async Task<Unit> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);
            course.Edit(request.Name, request.Description, request.Author, request.ReleaseDate, request.Level);
            await _courseRepository.UpdateAsync(course);
            foreach (var @event in course.DomainEvents)
            {
                await _mediator.Publish(@event);
            }
            return await Unit.Task;
        }
    }
}
