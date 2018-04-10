using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aula1MVC.Startup))]
namespace aula1MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
