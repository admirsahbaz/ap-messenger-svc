using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.Converters
{
    public class MessageConverter
    {
        public static Models.Message Convert(ApIosMessenger.EF.Models.Message chatMessage, int userId)
        {
            Models.Message message = new Models.Message();
            message.isSender = chatMessage.UserId == userId;
            message.text = chatMessage.Text;
            return message;
        }
    }
}
