using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Accreditaire.AppMvc.Startup))]
namespace Accreditaire.AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
