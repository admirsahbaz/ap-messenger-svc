using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.EF.Models
{
    public class UserContact
    {
        public UserContact()
        { }

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserContactId { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}
