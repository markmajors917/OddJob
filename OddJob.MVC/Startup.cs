using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OddJob.MVC.Startup))]
namespace OddJob.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
