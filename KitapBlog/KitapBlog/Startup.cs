using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KitapBlog.Startup))]
namespace KitapBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
