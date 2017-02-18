using ApIosMessenger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApIosMessenger.EF.DataAccess;

namespace ApIosMessenger.Services
{
    public class UsersService
    {
        public static async Task<string> RegisterUser(User usr)
        {
            return await UsersProvider.RegisterUser(usr);
        }
        
        public static async Task<int> GetUserIdByEmailPassword(string email, string password)
        {
            return await UsersProvider.GetUserIdByEmailPassword(email, password);
        }

        public static bool GetUserByEmailPassword(string email, string password)
        {
            return UsersProvider.GetUserByEmailPassword(email, password);
        }
        public static bool UpdatePassword(int userId, string password)
        {
            return UsersProvider.UpdatePassword(userId, password);
        }

    }
}
