using CourseStore.Domain.CourseAgg;
using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Domain.CourseAgg.Repository;
using MediatR;

namespace CourseStore.Application.Courses.Add
{
    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediator _mediator;

        public AddCourseCommandHandler(ICourseRepository courseRepository, IMediator mediator)
        {
            this._courseRepository=courseRepository;
            this._mediator=mediator;
        }

        public async Task<Unit> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = new Course(request.Name, request.Description, request.Author, request.ReleaseDate, request.Level);
            await _courseRepository.AddAsync(course);

            //foreach (var @event in course.DomainEvents)
            {
                // await _mediator.Publish(@event);
                await _mediator.Publish(new CourseCreated(course.Id, course.Name, "09358758908"));
            }
            return await Unit.Task;
        }
    }
}
