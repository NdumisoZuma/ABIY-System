using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABIY_One.Startup))]
namespace ABIY_One
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
