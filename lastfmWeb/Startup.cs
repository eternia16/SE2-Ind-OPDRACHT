using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lastfmWeb.Startup))]
namespace lastfmWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
