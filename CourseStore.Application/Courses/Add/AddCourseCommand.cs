using CourseStore.Domain.CourseAgg.Enum;
using MediatR;

namespace CourseStore.Application.Courses.Add
{
    public class AddCourseCommand : IRequest<int>
    {
        public string Name { get; private  set; }
        public string Description { get;private  set; }
        public string Author { get; private set; }
        public DateTime ReleaseDate { get;private  set; }
        public Level Level { get;private  set; }

        public AddCourseCommand(string name, string description, string author, DateTime releaseDate, Level level)
        {
            Name=name;
            Description=description;
            Author=author;
            ReleaseDate=releaseDate;
            Level=level;
        }
    }
    
}
