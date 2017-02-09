using ApIosMessenger.Converters;
using ApIosMessenger.Converters.Models;
using ApIosMessenger.EF.DataAccess;
using ApIosMessenger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.Services
{
    public class ChatService
    {
        public static async Task<List<Recent>> GetRecentChats(int userId)
        {
            if (userId <= 0)
                return new List<Recent>();
            List<Recent> result = new List<Recent>();
            List<Chat> chats = await ChatsProvider.GetChats(userId);
            foreach (var chat in chats)
            {
                result.Add(ChatRecentConverter.Convert(chat, userId));
            }
            return result;
        }

        public static async Task<List<ApIosMessenger.Converters.Models.Message>> GetMessagesForChatAndUser(int chatId, int userId)
        {
            if (chatId < 0)
                return new List<ApIosMessenger.Converters.Models.Message>();
            List<ApIosMessenger.Converters.Models.Message> result = new List<Converters.Models.Message>();
            List<EF.Models.Message> messages = await ChatsProvider.GetMessagesForChat(chatId);
            foreach (var message in messages)
            {
                result.Add(MessageConverter.Convert(message, userId));
            }
            return result;
        }
    }
}
