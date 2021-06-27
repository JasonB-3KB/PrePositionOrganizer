using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrePositionOrganizer.WebMVC.Startup))]
namespace PrePositionOrganizer.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
