using System.Collections.Generic;
using Owin;
using Owin.StatelessAuth;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using Nancy;
using System.Security.Claims;
using Nancy.Owin;
using System.Linq;
using Nancy.Security;
using System;

namespace ApIosMessengerService
{
    public class Startup : DefaultNancyBootstrapper
    {
        public void Configuration(IAppBuilder app)
        {
            app.RequiresStatelessAuth(new SecureTokenValidator(),
              new StatelessAuthOptions() { IgnorePaths = new List<string>(new[] { "/", "/login", "/register" }) })
                .UseNancy();

        }
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            var owinEnvironment = context.GetOwinEnvironment();
            var user = owinEnvironment["server.User"] as ClaimsPrincipal;

            if (user != null)
            {
                Claim cEmail = user.Claims.Where(t => t.Type == "email").FirstOrDefault();
                Claim cId = user.Claims.Where(t => t.Type == "id").FirstOrDefault();
                context.CurrentUser = new UserIdentity()
                {
                    UserName = cEmail != null ? cEmail.Value : "",
                    UserId = cId != null ? int.Parse(cId.Value) : -1
                };
            }
        }

    }
    public class UserIdentity : IUserIdentity
    {
        public IEnumerable<string> Claims { get; set; }

        public string UserName { get; set; }

        public int UserId { get; set; }
    }
}