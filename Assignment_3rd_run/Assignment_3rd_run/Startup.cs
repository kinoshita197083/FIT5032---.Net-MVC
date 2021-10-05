using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_3rd_run.Startup))]
namespace Assignment_3rd_run
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
