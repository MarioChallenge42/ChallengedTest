using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebChallenged.Startup))]
namespace WebChallenged
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
