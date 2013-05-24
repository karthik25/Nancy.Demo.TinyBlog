using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nancy.Demo.TinyBlog.Domain.Abstract;
using Nancy.Demo.TinyBlog.Domain.Entities;
using Nancy.Demo.TinyBlog.Domain.Utils;

namespace Nancy.Demo.TinyBlog.Domain.Converters
{
    public class PostLocator : ILocator
    {
        public List<Post> GetPosts(string basePath)
        {
            var postList = new List<Post>();
            var deserializer = new PostDeserializer();
            var files = Directory.GetFiles(basePath, "*.yml").ToList();
            files.ForEach(file =>
                {
                    var fileContent = GetFileContent(file);
                    try
                    {
                        var instance = deserializer.Serialize(fileContent);
                        instance.PostUrl = UrlGenerator.UrlFriendly(Path.GetFileNameWithoutExtension(file));
                        postList.Add(instance);
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch (Exception)
                    // ReSharper restore EmptyGeneralCatchClause
                    {
                        
                    }
                });
            return postList;
        }

        private static string GetFileContent(string file)
        {
            var reader = new StreamReader(file);
            var content = reader.ReadToEnd();
            reader.Close();
            return content;
        }
    }
}
