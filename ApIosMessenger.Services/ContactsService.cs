using ApIosMessenger.Converters;
using ApIosMessenger.Converters.Models;
using ApIosMessenger.EF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.Services
{
    public class ContactsService
    {
        public static List<UserContact> GetContacts()
        {
            var contactsEF = ContactsProvider.GetContacts();

            var contacts = new List<UserContact>();

            foreach(var cEf in contactsEF)
            {
                contacts.Add(UserContactConverter.Convert(cEf));

            }

            return contacts;
        }
    }
}
