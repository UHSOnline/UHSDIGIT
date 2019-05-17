using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRIZMA.Startup))]
namespace TRIZMA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
