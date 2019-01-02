using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CURD.Startup))]
namespace CURD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
