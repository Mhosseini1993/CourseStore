using CourseStore.Application.Courses.Add;
using CourseStore.Application.Shared;
using CourseStore.Domain.CourseAgg.Repository;
using CourseStore.Domain.UserAgg.Repository;
using CourseStore.Infrastructure.Persistent.EF;
using CourseStore.Infrastructure.Persistent.EF.Courses;
using CourseStore.Infrastructure.Persistent.EF.Users;
using CourseStore.Query.Courses.GetById;
using CourseStore.Query.Shared.Repository;
using CourseStore.Query.Users.Repository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CourseStore.Config
{
    public class ProjectConfig
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CourseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Local"))
                       .LogTo(_ => { }, LogLevel.None)
                       .EnableSensitiveDataLogging(false)
                       .EnableDetailedErrors(false);
            });



            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(AddCourseCommandValidator).Assembly);

            services.AddMediatR(typeof(AddCourseCommand).Assembly);
            services.AddMediatR(typeof(GetCourseByIdQuery).Assembly);

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        }
    }

}
