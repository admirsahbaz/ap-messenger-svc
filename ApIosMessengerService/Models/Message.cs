using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApIosMessengerService.Models
{
    public class Message
    {
        public string SourceId { get; set; }
        public string DestinationId { get; set; }
        public string MessageContent { get; set; }
    }
}