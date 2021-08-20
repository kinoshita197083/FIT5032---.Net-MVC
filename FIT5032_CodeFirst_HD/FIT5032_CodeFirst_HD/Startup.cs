using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032_CodeFirst_HD.Startup))]
namespace FIT5032_CodeFirst_HD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
