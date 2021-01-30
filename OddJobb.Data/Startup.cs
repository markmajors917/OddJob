using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OddJobb.Data.Startup))]
namespace OddJobb.Data
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
