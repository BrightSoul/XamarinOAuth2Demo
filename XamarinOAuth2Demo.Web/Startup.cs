using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XamarinOAuth2Demo.Web.Startup))]
namespace XamarinOAuth2Demo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
