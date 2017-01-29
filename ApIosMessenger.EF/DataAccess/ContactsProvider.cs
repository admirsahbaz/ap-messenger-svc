using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApIosMessenger.EF.Models;
using ApIosMessenger.EF;

namespace ApIosMessenger.EF.DataAccess
{
    public class ContactsProvider
    {
        public static List<UserContact> GetContacts()
        {
            var contacts  = new List<UserContact>();

            using (var ctx = new EFContext())
            {
                contacts = ctx.UserContacts.ToList<UserContact>();
            }
            return contacts;
        }
    }
}
