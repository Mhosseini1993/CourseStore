using CourseStore.Domain.UserAgg;
using CourseStore.Domain.UserAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infrastructure.Persistent.EF.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly CourseDbContext _dbContext;

        public UserRepository(CourseDbContext db)
        {
            this._dbContext=db;
        }
        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(ef => ef.Id==id);
        }

        public async Task UpdateAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
