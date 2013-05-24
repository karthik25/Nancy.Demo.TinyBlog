using System.IO;
using Nancy.Hosting.Aspnet;

namespace Nancy.Demo.TinyBlog.Providers
{
    public static class PathProvider
    {
        public static string GetPostsPath()
        {
            IRootPathProvider rootPathProvider = new AspNetRootSourceProvider();
            return GetPostsPath(rootPathProvider);
        }

        public static string GetPostsPath(IRootPathProvider rootPathProvider)
        {
            var rootPath = rootPathProvider.GetRootPath();
            var requiredPath = Path.Combine(rootPath, "Posts");
            return requiredPath;
        }
    }
}