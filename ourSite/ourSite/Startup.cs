using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ourSite.Startup))]
namespace ourSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
