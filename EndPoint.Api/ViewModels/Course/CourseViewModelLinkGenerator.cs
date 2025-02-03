using EndPoint.Api.ViewModels.Shared;

namespace EndPoint.Api.ViewModels.Course
{
    public static class CourseViewModelLinkGenerator
    {
        public const string BaseUrl = "sdfs";
        public static CourseViewModel GenerateLink(this CourseViewModel model)
        {
            var links = new List<LinkDto>()
            {
                new LinkDto(BaseUrl,"",HttpMethod.Get.Method)
            };
            model.LinkDtos.AddRange(links);
            return model;
        }
    }
}
