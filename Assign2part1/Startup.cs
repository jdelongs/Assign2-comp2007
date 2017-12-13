using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assign2part1.Startup))]
namespace Assign2part1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
