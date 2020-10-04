using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewSkillsAsp.Startup))]
namespace NewSkillsAsp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
