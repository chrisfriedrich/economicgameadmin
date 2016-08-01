using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Economic_Game__Admin_.Startup))]
namespace Economic_Game__Admin_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
