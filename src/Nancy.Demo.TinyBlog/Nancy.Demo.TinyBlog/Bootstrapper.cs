using Nancy.Conventions;
using Nancy.Demo.TinyBlog.Domain.Abstract;
using Nancy.Demo.TinyBlog.Domain.Converters;

namespace Nancy.Demo.TinyBlog
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));
            base.ConfigureConventions(nancyConventions);
        }

        protected override void ConfigureApplicationContainer(TinyIoc.TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<ILocator, PostLocator>();
        }
    }
}