using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterApplication_SSluzbaMVC.Startup))]
namespace MasterApplication_SSluzbaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
