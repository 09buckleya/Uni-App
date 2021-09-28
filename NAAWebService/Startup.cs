using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAAWebService.Startup))]
namespace NAAWebService
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
