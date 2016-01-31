using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Investor.Web.Startup))]
namespace Investor.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
