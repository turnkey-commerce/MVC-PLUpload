using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlUpload.Startup))]
namespace PlUpload
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
