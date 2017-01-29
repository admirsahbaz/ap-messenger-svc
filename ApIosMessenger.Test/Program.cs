using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApIosMessenger.EF;
using ApIosMessenger.EF.Models;
using System.Data.Entity;

namespace ApIosMessenger.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFContext())
            {
                User usr = new User() { Name = "User1", Email="m@m.com", Password="Pass1"};

                UserContact usercontact = new UserContact();
                usercontact.UserId = 5;
                usercontact.UserContactId = 16;

                Chat chat = new Chat();
                chat.ChatTitle = "Chat 1";
                chat.DateCreated = DateTime.UtcNow;

                //chat.Users.Add(usr);

                //for (int i= 1; i<10; i++)
                //{
                //    var message = new Message();
                //    message.Text = String.Format("Test message {0}, chat {1}", i, chat.ChatId);
                //    message.MessageTime = DateTime.UtcNow;
                //    message.User = usr;5
                //    message.Chat = chat;
                //    ctx.Messages.Add(message);

                //}

                //ctx.Chats.Add(chat);
                ctx.UserContacts.Add(usercontact);
                //ctx.Users.Add(usr);
                ctx.SaveChanges();
            }
        }
    }
}
