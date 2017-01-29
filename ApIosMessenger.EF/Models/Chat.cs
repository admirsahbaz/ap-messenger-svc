using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.EF.Models
{
    public class Chat
    {
        public Chat()
        {
            this.Users = new HashSet<User>();
            this.Messages = new HashSet<Message>();
        }

        public int ChatId { get; set; }
        public string ChatTitle { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
