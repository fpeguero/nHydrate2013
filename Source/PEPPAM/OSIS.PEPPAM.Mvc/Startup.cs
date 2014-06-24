using Owin;

namespace OSIS.PEPPAM.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure OWIN pipeline here
            ConfigureAuth(app);
        }
    }
}