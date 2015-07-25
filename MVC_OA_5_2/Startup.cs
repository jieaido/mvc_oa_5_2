using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvc_oa_new.Startup))]
namespace mvc_oa_new
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
