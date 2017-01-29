using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.EF.Models
{
    public class Message
    {

        public Message()
        { }

        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
        public DateTime MessageTime { get; set; }

        public virtual User User { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
