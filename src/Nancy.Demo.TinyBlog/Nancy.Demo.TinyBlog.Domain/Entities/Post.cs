using System;

namespace Nancy.Demo.TinyBlog.Domain.Entities
{
    public class Post
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
        public string[] Tags { get; set; }

        public string PostUrl { get; set; }
    }
}
