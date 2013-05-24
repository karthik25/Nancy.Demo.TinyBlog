using System.IO;
using Nancy.Demo.TinyBlog.Domain.Entities;
using YamlDotNet.RepresentationModel.Serialization;

namespace Nancy.Demo.TinyBlog.Domain.Converters
{
    public class PostSerializer
    {
        public string Serialize(Post post)
        {
            var writer = new StringWriter();
            var yamlSerializer = new Serializer();
            yamlSerializer.Serialize(writer, post);
            return writer.ToString();
        }
    }
}
