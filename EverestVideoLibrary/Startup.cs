using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EverestVideoLibrary.Startup))]
namespace EverestVideoLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
