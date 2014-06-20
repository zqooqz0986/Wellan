using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(welcomMVC.Startup))]
namespace welcomMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
