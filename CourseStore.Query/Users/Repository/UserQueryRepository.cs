using CourseStore.Query.Shared.Repository;
using CourseStore.Query.Users.DTOs;
using MongoDB.Driver;

namespace CourseStore.Query.Users.Repository
{
    public class UserQueryRepository :GenericRepository<UserReadModel>, IUserQueryRepository
    {
        public UserQueryRepository(IMongoClient client) : base(client)
        {
        }
        public async Task<UserReadModel> GetByPhoneNumberAsync(string phoneNumber)
        {
            var res = await _collection.Find(ef => ef.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
            return res;
        }
    }
}
