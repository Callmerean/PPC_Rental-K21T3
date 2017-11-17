using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PPC_Rental.Startup))]
namespace PPC_Rental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
