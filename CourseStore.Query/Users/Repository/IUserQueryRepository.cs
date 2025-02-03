using CourseStore.Query.Shared;
using CourseStore.Query.Shared.Repository;
using CourseStore.Query.Users.DTOs;

namespace CourseStore.Query.Users.Repository
{
    public interface IUserQueryRepository : IGenericRepository<UserReadModel>
    {
        Task<UserReadModel> GetByPhoneNumberAsync(string phoneNumber);
    }
}
