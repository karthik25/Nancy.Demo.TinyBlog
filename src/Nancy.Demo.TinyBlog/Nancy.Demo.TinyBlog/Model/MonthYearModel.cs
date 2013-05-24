using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Nancy.Demo.TinyBlog.Domain.Abstract;
using Nancy.Demo.TinyBlog.Domain.Converters;
using Nancy.Demo.TinyBlog.Providers;

namespace Nancy.Demo.TinyBlog.Model
{
    public class MonthYearModel
    {
        public string Slug { get; set; }
        public string MonthYear { get; set; }

        public static List<MonthYearModel> GetBlogArchives()
        {
            ILocator postLocator = new PostLocator();
            var posts = postLocator.GetPosts(PathProvider.GetPostsPath());
            var group = posts.GroupBy(p => new {p.DateCreated.Year, p.DateCreated.Month})
                             .OrderByDescending(g => g.Key.Year)
                             .ThenByDescending(g => g.Key.Month);
            return @group.Select(g => new MonthYearModel { MonthYear = string.Format("{0} {1}", GetMonthName(g.Key.Month), g.Key.Year), 
                                                           Slug = string.Format("{0}/{1}/{2}", Constants.BlogBasePath, g.Key.Year, g.Key.Month.ToString("00"))})
                         .ToList();
        }

        private static string GetMonthName(int monthNumber)
        {
            var dateTime = new DateTime(DateTime.Now.Year, monthNumber, 1);
            return dateTime.ToString("MMM", CultureInfo.InvariantCulture);
        }
    }
}