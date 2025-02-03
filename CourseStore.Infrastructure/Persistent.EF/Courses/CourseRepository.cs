using CourseStore.Domain.CourseAgg;
using CourseStore.Domain.CourseAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.Infrastructure.Persistent.EF.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseDbContext _dbContext;

        public CourseRepository(CourseDbContext db)
        {
            _dbContext = db;
        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _dbContext.Courses.Where(ef => ef.Id == id).FirstOrDefaultAsync();
        }
        public async Task AddAsync(Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Course course)
        {
            _dbContext.Courses.Update(course);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var itemForDelete = await GetByIdAsync(id);
            _dbContext.Courses.Remove(itemForDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
