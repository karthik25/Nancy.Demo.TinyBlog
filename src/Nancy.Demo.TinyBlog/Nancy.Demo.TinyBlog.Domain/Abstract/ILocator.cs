using System.Collections.Generic;
using Nancy.Demo.TinyBlog.Domain.Entities;

namespace Nancy.Demo.TinyBlog.Domain.Abstract
{
    public interface ILocator
    {
        List<Post> GetPosts(string basePath);
    }
}
