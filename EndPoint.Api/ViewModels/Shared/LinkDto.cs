namespace EndPoint.Api.ViewModels.Shared
{
    public class LinkDto
    {
        public string Url { get; private set; }
        public string Rel { get; private set; }
        public string Method { get; private set; }
        public LinkDto(string url, string rel, string method)
        {
            Url = url;
            Rel = rel;
            Method = method;
        }
    }
}
