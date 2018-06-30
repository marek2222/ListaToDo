using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ListaToDo.Startup))]
namespace ListaToDo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
