using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.EF.Models
{
    public class User
    {
        public User()
        {
            this.Chats = new HashSet<Chat> ();
            this.Contacts = new HashSet<UserContact>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Chat> Chats { get; set; }

        public virtual ICollection<UserContact> Contacts { get; set; }
    }
}
