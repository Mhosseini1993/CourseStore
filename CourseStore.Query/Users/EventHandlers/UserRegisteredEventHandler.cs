using CourseStore.Domain.UserAgg.Events;
using CourseStore.Domain.UserAgg.Repository;
using CourseStore.Query.Shared.Repository;
using CourseStore.Query.Users.DTOs;
using MediatR;

namespace CourseStore.Query.Users.EventHandlers
{
    public class UserRegisteredEventHandler : INotificationHandler<UserRegistered>
    {
        private readonly IUserRepository _writeRepository;
        private readonly IGenericRepository<UserReadModel> _readRepository;

        public UserRegisteredEventHandler(IUserRepository userRepository, IGenericRepository<UserReadModel> genericRepository)
        {
            this._writeRepository=userRepository;
            this._readRepository=genericRepository;
        }
        public async Task Handle(UserRegistered notification, CancellationToken cancellationToken)
        {
            var user =await _writeRepository.GetByIdAsync(notification.UserId);
            await _readRepository.AddAsync(new UserReadModel()
            {
                Id = notification.UserId,   
                FullName= $"{user.FirstName} {user.LastName}",
                PhoneNumber= notification.PhoneNumber,
            });
        }
    }
}
