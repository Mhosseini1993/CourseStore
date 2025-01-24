using CourseStore.Domain.CourseAgg.Enum;
using MediatR;

namespace CourseStore.Application.Courses.Edit
{
    public class EditCourseCommand : IRequest
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Level Level { get; private set; }

        public EditCourseCommand(int id, string name, string description, string author, DateTime releaseDate, Level level)
        {
            Id=id;
            Name=name;
            Description=description;
            Author=author;
            ReleaseDate=releaseDate;
            Level=level;
        }
    }
}
