using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Class.Startup))]
namespace E_Class
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
