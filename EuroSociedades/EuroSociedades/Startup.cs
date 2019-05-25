using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EuroSociedades.Startup))]
namespace EuroSociedades
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
