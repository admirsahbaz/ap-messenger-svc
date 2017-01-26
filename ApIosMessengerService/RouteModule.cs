using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApIosMessengerService
{
    public class RouteModule : NancyModule
    {
        public RouteModule()
        {
            Get["/"] = _ => Response.AsJson<string>("ApIosMessengerService v.1.0", HttpStatusCode.OK);
        }
    }
}