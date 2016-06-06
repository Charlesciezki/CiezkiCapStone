using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCiezkiCapstone.Startup))]
namespace CCiezkiCapstone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
