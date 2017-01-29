using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApIosMessenger.EF.Models;
using ApIosMessenger.Converters.Models;

namespace ApIosMessenger.Converters
{
    public class UserContactConverter
    {
        public static Models.UserContact Convert(ApIosMessenger.EF.Models.UserContact ucEF)
        {
            Models.UserContact uc = new Models.UserContact();
            uc.Id = ucEF.Id;
            uc.UserContactId = ucEF.UserContactId;
            uc.UserId = ucEF.UserId;

            return uc;

        }
    }
}
