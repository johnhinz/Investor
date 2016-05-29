using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Investor.MVC.Startup))]
namespace Investor.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
