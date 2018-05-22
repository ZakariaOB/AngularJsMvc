using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularJsMvc.Startup))]
namespace AngularJsMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
