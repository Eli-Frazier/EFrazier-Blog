using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFrazier_Blog.Startup))]
namespace EFrazier_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
