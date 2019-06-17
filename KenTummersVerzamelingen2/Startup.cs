using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KenTummersVerzamelingen2.Startup))]
namespace KenTummersVerzamelingen2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
