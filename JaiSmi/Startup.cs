using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JaiSmi.Startup))]
namespace JaiSmi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
