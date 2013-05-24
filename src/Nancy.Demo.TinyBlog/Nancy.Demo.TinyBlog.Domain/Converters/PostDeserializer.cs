using System.IO;
using Nancy.Demo.TinyBlog.Domain.Entities;
using YamlDotNet.RepresentationModel.Serialization;

namespace Nancy.Demo.TinyBlog.Domain.Converters
{
    public class PostDeserializer
    {
        public Post Serialize(string postContent)
        {
            var sWriter = new StringReader(postContent);
            var yamlSerializer = new YamlSerializer<Post>();
            return yamlSerializer.Deserialize(sWriter);
        }
    }
}
