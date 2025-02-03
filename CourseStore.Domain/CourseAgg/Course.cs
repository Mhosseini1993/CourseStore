using CourseStore.Domain.CourseAgg.Enum;
using CourseStore.Domain.CourseAgg.Events;
using CourseStore.Domain.Shared;
using CourseStore.Domain.Shared.Exceptions;

namespace CourseStore.Domain.CourseAgg
{
    public class Course : BaseAggregate
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Author { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Level Level { get; private set; }

        public Course(string name, string description, string author, DateTime releaseDate, Level level)
        {
            NullOrEmptyDomainDataException.CheckIfNull(name, nameof(name));
            NullOrEmptyDomainDataException.CheckIfNull(description, nameof(description));
            NullOrEmptyDomainDataException.CheckIfNull(author, nameof(author));

            Description=description;
            Author=author;
            ReleaseDate=releaseDate;
            Level=level;

            //AddDomainEvent(new CourseCreated(Id, author, "09358758908"));
        }
        public void Edit(string name, string description, string author, DateTime releaseDate, Level level)
        {
            NullOrEmptyDomainDataException.CheckIfNull(name, nameof(name));
            NullOrEmptyDomainDataException.CheckIfNull(description, nameof(description));
            NullOrEmptyDomainDataException.CheckIfNull(author, nameof(author));

            Name=name;
            Description=description;
            Author=author;
            ReleaseDate=releaseDate;
            Level=level;

            AddDomainEvent(new CourseEdited(Id));
        }

    }
}
