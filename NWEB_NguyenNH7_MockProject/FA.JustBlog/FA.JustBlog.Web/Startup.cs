using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FA.JustBlog.Web.Startup))]
namespace FA.JustBlog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
