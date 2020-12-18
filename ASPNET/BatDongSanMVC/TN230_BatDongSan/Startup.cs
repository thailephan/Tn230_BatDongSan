using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TN230_BatDongSan.Startup))]
namespace TN230_BatDongSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
