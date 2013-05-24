using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Nancy.Demo.TinyBlog.Domain.Abstract;
using Nancy.Demo.TinyBlog.Domain.Converters;
using Nancy.Hosting.Aspnet;

namespace Nancy.Demo.TinyBlog.Model
{
    public class MonthYearModel
    {
        public string Slug { get; set; }
        public string MonthYear { get; set; }

        public static List<MonthYearModel> GetBlogArchives()
        {
            ILocator postLocator = new PostLocator();
            var posts = postLocator.GetPosts(GetPostsPath());
            var group = posts.GroupBy(p => new {p.DateCreated.Year, p.DateCreated.Month})
                             .OrderByDescending(g => g.Key.Year)
                             .ThenByDescending(g => g.Key.Month);
            return @group.Select(g => new MonthYearModel { MonthYear = string.Format("{0} {1}", GetMonthName(g.Key.Month), g.Key.Year), 
                                                           Slug = string.Format("{0}/{1}/{2}", BasePath, g.Key.Year, g.Key.Month.ToString("00"))})
                         .ToList();
        }

        private static string GetPostsPath()
        {
            IRootPathProvider rootPathProvider = new AspNetRootSourceProvider();
            var rootPath = rootPathProvider.GetRootPath();
            var requiredPath = Path.Combine(rootPath, "Posts");
            return requiredPath;
        }

        private static string GetMonthName(int monthNumber)
        {
            var dateTime = new DateTime(DateTime.Now.Year, monthNumber, 1);
            return dateTime.ToString("MMM", CultureInfo.InvariantCulture);
        }

        private const string BasePath = "/blog";
    }
}