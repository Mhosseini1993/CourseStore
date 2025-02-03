using CourseStore.Domain.CourseAgg;
using CourseStore.Domain.Shared;
using CourseStore.Domain.UserAgg;
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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<BaseDomainEvent>();

            builder.Entity<User>().OwnsOne(ef => ef.PhoneNumber, option =>
            {
                option.Property(ef => ef.Number)
                      .HasColumnName("PhoneNumber");
            });

            base.OnModelCreating(builder);
        }

    }
}
