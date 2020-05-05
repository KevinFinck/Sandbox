using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThirdPartyTools.Startup))]
namespace ThirdPartyTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
