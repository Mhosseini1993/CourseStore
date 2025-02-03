using CourseStore.Query.Shared.Repository;
using CourseStore.Query.Users.DTOs;
using CourseStore.Query.Users.Repository;
using MediatR;

namespace CourseStore.Query.Users.GetByPhoneNumber
{
    public class GetUserByPhoneNumberQueryHandler : IRequestHandler<GetUserByPhoneNumberQuery, UserReadModel>
    {
        private readonly IUserQueryRepository _repository;

        public GetUserByPhoneNumberQueryHandler(IUserQueryRepository repository)
        {
            this._repository=repository;
        }
        public async Task<UserReadModel> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetByPhoneNumberAsync(request.phoneNumber);
            return res;
        }
    }
}
