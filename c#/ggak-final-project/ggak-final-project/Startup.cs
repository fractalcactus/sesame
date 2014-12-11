using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ggak_final_project.Startup))]
namespace ggak_final_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
