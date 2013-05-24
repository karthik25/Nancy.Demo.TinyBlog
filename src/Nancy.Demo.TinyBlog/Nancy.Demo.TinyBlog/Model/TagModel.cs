using System.Collections.Generic;
using System.Linq;
using Nancy.Demo.TinyBlog.Domain.Abstract;
using Nancy.Demo.TinyBlog.Domain.Converters;
using Nancy.Demo.TinyBlog.Domain.Utils;
using Nancy.Demo.TinyBlog.Providers;

namespace Nancy.Demo.TinyBlog.Model
{
    public class TagModel
    {
        public string TagSlug { get; set; }
        public string TagText { get; set; }

        public static List<TagModel> GetBlogTags()
        {
            ILocator postLocator = new PostLocator();
            var posts = postLocator.GetPosts(PathProvider.GetPostsPath());
            var allTags = posts.SelectMany(p => p.Tags).ToList().Distinct();
            return allTags.Select(t => new TagModel { TagText = t, TagSlug = string.Format("{0}/tag/{1}", Constants.BlogBasePath, UrlGenerator.UrlFriendly(t)) }).ToList();
        }
    }
}