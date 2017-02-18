using ApIosMessenger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.EF.DataAccess
{
    public class ChatsProvider
    {
        public static async Task<List<Chat>> GetChats(int userId)
        {
            try
            {
                using (var ctx = new EFContext())
                {
                    return ctx.Chats.Include("Users").Include("Messages").Where(c => c.Users.Any(u => u.Id == userId)).OrderByDescending(c => c.Messages.Max(m => m.MessageTime)).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Chat>();
            }
        }

        public static async Task<List<Message>> GetMessagesForChat(int chatId)
        {
            try
            {
                using (var ctx = new EFContext())
                {
                    return ctx.Messages.Where(m => m.ChatId == chatId).OrderBy(m => m.MessageTime).ToList();
                   //return ctx.Chats.Include("Users").Include("Messages").Where(c => c.Users.Any(u => u.Id == userId)).OrderBy(c => c.Messages.Max(m => m.MessageTime)).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Message>();
            }
        }
    }
}
