namespace CourseStore.Domain.UserAgg.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> GetByIdAsync(int id);
    }
}
