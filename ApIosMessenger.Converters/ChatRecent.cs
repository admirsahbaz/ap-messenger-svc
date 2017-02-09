using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.Converters
{
    public class ChatRecentConverter
    {
        public static Models.Recent Convert(ApIosMessenger.EF.Models.Chat chatEF, int userId)
        {
            Models.Recent recent = new Models.Recent();
            recent.ChatId = chatEF.ChatId;
            recent.Name = chatEF.Users.Where(u => u.Id != userId).FirstOrDefault().Name;
            recent.LastMessage = chatEF.Messages.OrderByDescending(m => m.MessageTime).FirstOrDefault().Text;
            return recent;
        }
    }
}
