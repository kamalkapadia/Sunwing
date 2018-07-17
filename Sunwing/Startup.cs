using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sunwing.Startup))]
namespace Sunwing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
