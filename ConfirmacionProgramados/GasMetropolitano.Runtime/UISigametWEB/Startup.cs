using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UISigametWEB.Startup))]
namespace UISigametWEB
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
