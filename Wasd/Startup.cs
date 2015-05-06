using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wasd.Startup))]
namespace Wasd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
