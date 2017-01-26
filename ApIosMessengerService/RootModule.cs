using ApIosMessengerService.Models;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApIosMessengerService
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = _ => Response.AsJson<string>("ApIosMessengerService v.1.0", HttpStatusCode.OK);
            Post["/login", runAsync: true] = async (x, ct) => await Authenticate(this.Bind<LoginModel>());
        }

        private async Task<dynamic> Authenticate(LoginModel model)
        {
            string token = "null";
            HttpStatusCode statusCode = HttpStatusCode.OK;

            if (model != null && (model.Email == "test@authoritypartners.com" && model.Password == "test"))
                token = Guid.NewGuid().ToString();
            else
                statusCode = HttpStatusCode.Unauthorized;

            return new Response()
            {
                ContentType = "application/json",
                StatusCode = statusCode,
                Contents = _ =>
                {
                    using (System.IO.StreamWriter w = new System.IO.StreamWriter(_))
                    {
                        w.Write(token);
                        w.Flush();
                    }
                }
            };
        }
    }
}