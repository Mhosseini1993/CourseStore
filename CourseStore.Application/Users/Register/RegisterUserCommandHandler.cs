using CourseStore.Domain.UserAgg;
using CourseStore.Domain.UserAgg.Events;
using CourseStore.Domain.UserAgg.Repository;
using MediatR;

namespace CourseStore.Application.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IMediator mediator, IUserRepository userRepository)
        {
            this._mediator=mediator;
            this._userRepository=userRepository;
        }
        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User(" ", " ", request.PhoneNumber);
            await _userRepository.AddAsync(user);
            await _mediator.Publish(new UserRegistered(user.Id, request.PhoneNumber.Number));
            return await Unit.Task;
        }
    }
}
