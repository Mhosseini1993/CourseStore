using CourseStore.Query.Shared;

namespace CourseStore.Query.Users.DTOs
{
    public class UserReadModel : BaseReadModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
