using CourseStore.Domain.CourseAgg.Enum;
using System.ComponentModel.DataAnnotations;

namespace EndPoint.UI.Shared.Models
{
    public class EditCourseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [EnumDataType(typeof(Level), ErrorMessage = "Please select level")]
        public Level Level { get; set; }

    }
}
