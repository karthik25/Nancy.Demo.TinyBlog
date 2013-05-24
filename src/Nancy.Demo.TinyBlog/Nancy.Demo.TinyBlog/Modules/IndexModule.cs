namespace Nancy.Demo.TinyBlog.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["Index.cshtml"];
        }
    }
}