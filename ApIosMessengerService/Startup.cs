using System.Collections.Generic;
using Owin;
using Owin.StatelessAuth;

namespace ApIosMessengerService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.RequiresStatelessAuth(new SecureTokenValidator(),
              new StatelessAuthOptions() { IgnorePaths = new List<string>(new[] { "/", "/login", "/register" }) })
                .UseNancy();
        }
    }
}