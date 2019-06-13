using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INFT3050_Assignment_2.Startup))]
namespace INFT3050_Assignment_2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
