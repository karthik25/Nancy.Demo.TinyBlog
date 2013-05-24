using System.Collections.Generic;
using Nancy.Demo.TinyBlog.Domain.Entities;

namespace Nancy.Demo.TinyBlog.Model
{
    public class PostListingModel
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public string Tag { get; set; }
        public List<Post> Posts { get; set; }
    }
}