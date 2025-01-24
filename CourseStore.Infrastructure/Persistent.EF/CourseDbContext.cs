using CourseStore.Domain.CourseAgg;
using CourseStore.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CourseStore.Infrastructure.Persistent.EF
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<BaseDomainEvent>();
            base.OnModelCreating(builder);
        }

    }
}
