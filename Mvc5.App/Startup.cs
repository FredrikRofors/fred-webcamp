using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc5.App.Startup))]
namespace Mvc5.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
