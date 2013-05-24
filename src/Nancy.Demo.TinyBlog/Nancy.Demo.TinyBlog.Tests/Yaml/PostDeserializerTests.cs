using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Demo.TinyBlog.Domain.Converters;

namespace Nancy.Demo.TinyBlog.Tests.Yaml
{
    [TestClass]
    public class PostDeserializerTests
    {
        [TestMethod]
        public void CanDeserializePostYaml()
        {
            var postSerializer = new PostDeserializer();
            var serializedPost = postSerializer.Serialize(Post);
            Assert.IsNotNull(serializedPost);
            Assert.AreEqual("Lorem Ipsum Dolor", serializedPost.Title);
            Assert.AreEqual("5/18/2013", serializedPost.DateCreated.ToShortDateString());
            Assert.AreEqual("5/18/2013", serializedPost.DateEdited.ToShortDateString());
            Assert.AreEqual("Lorem ipsum dolor sit amet, consectetur <b>adipiscing</b> elit. Sed orci ante, tincidunt vitae hendrerit aliquam, molestie in nulla. Vestibulum sit amet mollis libero. Curabitur sit amet porta dui. Proin lectus urna, vulputate ac laoreet ut, scelerisque id neque. Etiam posuere metus et justo vestibulum egestas a id arcu. Suspendisse commodo ipsum ac nisi volutpat posuere facilisis dui pretium. Mauris mollis, felis quis laoreet faucibus, felis eros imperdiet ipsum, et congue mauris erat ac justo. Duis molestie venenatis magna, et convallis elit fermentum sed. Nulla tortor diam, auctor non suscipit at, sagittis ut est. Nam purus felis, hendrerit sit amet sodales sit amet, feugiat at sapien. Donec sed tellus nisl, id suscipit massa. Curabitur iaculis, dui ac mattis cursus, enim eros imperdiet lacus, eget egestas orci dui ut nibh. Aenean in sapien ipsum.", serializedPost.Content);
            Assert.AreEqual(3, serializedPost.Tags.Count());
            Assert.IsTrue(serializedPost.Tags.Contains("ASP.Net"));
            Assert.IsTrue(serializedPost.Tags.Contains("C#"));
            Assert.IsTrue(serializedPost.Tags.Contains("IronRuby"));
        }

        public const string Post = @"---
                                     title: Lorem Ipsum Dolor
                                     date_created: 2013-05-18
                                     date_edited: 2013-05-18
                                     content: Lorem ipsum dolor sit amet, consectetur <b>adipiscing</b> elit. Sed orci ante, tincidunt vitae hendrerit aliquam, molestie in nulla. Vestibulum sit amet mollis libero. Curabitur sit amet porta dui. Proin lectus urna, vulputate ac laoreet ut, scelerisque id neque. Etiam posuere metus et justo vestibulum egestas a id arcu. Suspendisse commodo ipsum ac nisi volutpat posuere facilisis dui pretium. Mauris mollis, felis quis laoreet faucibus, felis eros imperdiet ipsum, et congue mauris erat ac justo. Duis molestie venenatis magna, et convallis elit fermentum sed. Nulla tortor diam, auctor non suscipit at, sagittis ut est. Nam purus felis, hendrerit sit amet sodales sit amet, feugiat at sapien. Donec sed tellus nisl, id suscipit massa. Curabitur iaculis, dui ac mattis cursus, enim eros imperdiet lacus, eget egestas orci dui ut nibh. Aenean in sapien ipsum.
                                     tags:
                                         - ASP.Net
                                         - C#
                                         - IronRuby";
    }
}
