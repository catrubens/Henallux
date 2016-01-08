using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeditGestionRisqueLesire.Startup))]
namespace MeditGestionRisqueLesire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
