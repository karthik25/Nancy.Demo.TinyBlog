using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Demo.TinyBlog.Domain.Converters;
using Nancy.Demo.TinyBlog.Domain.Entities;

namespace Nancy.Demo.TinyBlog.Tests.Yaml
{
    [TestClass]
    public class PostSerializerTests
    {
        [TestMethod]
        public void CanSerializePostInstance()
        {
            var post = new Post
                {
                    Title = "Lorem Ipsum Dolor",
                    DateCreated = DateTime.Parse("5/18/2013"),
                    DateEdited = DateTime.Parse("5/18/2013"),
                    Content = "Lorem ipsum dolor sit amet, consectetur <b>adipiscing</b> elit. Sed orci ante, tincidunt vitae hendrerit aliquam, molestie in nulla. Vestibulum sit amet mollis libero. Curabitur sit amet porta dui. Proin lectus urna, vulputate ac laoreet ut, scelerisque id neque. Etiam posuere metus et justo vestibulum egestas a id arcu. Suspendisse commodo ipsum ac nisi volutpat posuere facilisis dui pretium. Mauris mollis, felis quis laoreet faucibus, felis eros imperdiet ipsum, et congue mauris erat ac justo. Duis molestie venenatis magna, et convallis elit fermentum sed. Nulla tortor diam, auctor non suscipit at, sagittis ut est. Nam purus felis, hendrerit sit amet sodales sit amet, feugiat at sapien. Donec sed tellus nisl, id suscipit massa. Curabitur iaculis, dui ac mattis cursus, enim eros imperdiet lacus, eget egestas orci dui ut nibh. Aenean in sapien ipsum.", 
                    Tags = new[]{ "ASP.Net","C#" }
                };
            var serializer = new PostSerializer();
            var serializedString = serializer.Serialize(post);

            var postSerializer = new PostDeserializer();
            var serializedPost = postSerializer.Serialize(serializedString);
            Assert.IsNotNull(serializedPost);

            Assert.IsTrue(!string.IsNullOrEmpty(serializedString));
            Assert.IsTrue(serializedString.IndexOf("Lorem ipsum dolor sit amet, consectetur <b>adipiscing</b> elit. Sed orci ante, tincidunt vitae hendrerit aliquam, molestie in nulla. Vestibulum sit amet mollis libero. Curabitur sit amet porta dui. Proin lectus urna, vulputate ac laoreet ut, scelerisque id neque. Etiam posuere metus et justo vestibulum egestas a id arcu. Suspendisse commodo ipsum ac nisi volutpat posuere facilisis dui pretium. Mauris mollis, felis quis laoreet faucibus, felis eros imperdiet ipsum, et congue mauris erat ac justo. Duis molestie venenatis magna, et convallis elit fermentum sed. Nulla tortor diam, auctor non suscipit at, sagittis ut est. Nam purus felis, hendrerit sit amet sodales sit amet, feugiat at sapien. Donec sed tellus nisl, id suscipit massa. Curabitur iaculis, dui ac mattis cursus, enim eros imperdiet lacus, eget egestas orci dui ut nibh. Aenean in sapien ipsum.", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(serializedString.IndexOf("ASP.Net", StringComparison.Ordinal) >= 0);
            Assert.IsTrue(serializedString.IndexOf("C#", StringComparison.Ordinal) >= 0);
        }
    }
}
