using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OddJob.data.Startup))]
namespace OddJob.data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
