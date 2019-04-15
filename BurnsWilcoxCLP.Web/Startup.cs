using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BurnsWilcoxCLP.Web.Startup))]
namespace BurnsWilcoxCLP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
