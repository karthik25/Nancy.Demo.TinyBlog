using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Demo.TinyBlog.Domain.Converters;

namespace Nancy.Demo.TinyBlog.Tests.Locators
{
    [TestClass]
    public class PostLocatorTests
    {
        [TestMethod]
        public void CanLocatePostsWithinThePostsFolder()
        {
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            foreach (var resource in resources)
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
                if (stream != null)
                {
                    var reader = new StreamReader(stream);
                    var content = reader.ReadToEnd();
                    var deserializer = new PostDeserializer();
                    var instance = deserializer.Serialize(content);
                    Assert.IsTrue(!string.IsNullOrEmpty(instance.Title));
                }
            }
        }
    }
}
