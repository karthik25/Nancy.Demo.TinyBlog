using System.Globalization;
using System.IO;
using System.Linq;
using Nancy.Demo.TinyBlog.Domain.Abstract;
using Nancy.Demo.TinyBlog.Domain.Utils;
using Nancy.Demo.TinyBlog.Model;

namespace Nancy.Demo.TinyBlog.Modules
{
    public class HomeModule : NancyModule
    {
        private readonly ILocator _locator;
        private readonly IRootPathProvider _rootPathProvider;

        public HomeModule(ILocator locator, IRootPathProvider rootPathProvider)
            : base("/blog")
        {
            _locator = locator;
            _rootPathProvider = rootPathProvider;

            Get["/"] = parameters => RenderIndex(parameters);
            Get["/404"] = parameters => Render404(parameters);
            Get["/about"] = parameters => RenderAbout(parameters);
            Get["/{year}/{month}"] = parameters => RenderPosts(parameters);
            Get["/tag/{tagId}"] = parameters => RenderPostsByTag(parameters);
            Get["/{post_url}"] = parameters => RenderPost(parameters);
        }

        private object RenderIndex(dynamic parameters)
        {
            var list = _locator.GetPosts(GetPostsPath());
            var model = new PostListingModel { Posts = list };
            return View["Index", model];
        }

        private object RenderAbout(dynamic parameters)
        {
            return View["About"];
        }

        private object RenderPosts(dynamic parameters)
        {
            var year = parameters.year;
            var month = parameters.month;
            var list = _locator.GetPosts(GetPostsPath());
            var posts = new PostListingModel
                {
                    Year = year, 
                    Month = month, 
                    Posts = list.Where(i => i.DateCreated.Year.ToString(CultureInfo.InvariantCulture) == year && 
                                            i.DateCreated.Month.ToString("00") == month).ToList()
                };
            return View["Posts", posts];
        }

        private object RenderPostsByTag(dynamic parameters)
        {
            var tag = parameters.tagId;
            var list = _locator.GetPosts(GetPostsPath());
            var posts = new PostListingModel {Tag = tag, Posts = list.Where(l => l.Tags.Select(UrlGenerator.UrlFriendly).ToList().Contains(tag)).ToList()};
            return View["Posts", posts];
        }

        private object RenderPost(dynamic parameters)
        {
            var postUrl = parameters.post_url;
            var list = _locator.GetPosts(GetPostsPath());
            var requiredPost = list.SingleOrDefault(l => l.PostUrl == postUrl);

            if (requiredPost == null)
            {
                return View["NotFound"];
            }

            var post = new PostViewModel { Post = requiredPost };
            return View["Post", post];
        }

        public object Render404(dynamic parameters)
        {
            return View["NotFound"];
        }

        private string GetPostsPath()
        {
            var rootPath = _rootPathProvider.GetRootPath();
            var requiredPath = Path.Combine(rootPath, "Posts");
            return requiredPath;
        }
    }
}