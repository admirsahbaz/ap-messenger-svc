using ApIosMessenger.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApIosMessenger.EF.DataAccess
{
    public class UsersProvider
    {
        public static async Task<string> RegisterUser(User usr)
        {
            try
            {
                using (var ctx = new EFContext())
                {
                    if (ctx.Users.Any(u => u.Email == usr.Email))
                        return "An account with that email already exists";
                    ctx.Users.Add(usr);
                    int saved = await ctx.SaveChangesAsync();
                    if (saved != 0)
                        return "Registration complete";
                    return "An Error ocurred";
                }
            }
            catch (Exception)
            {
                return "An Error ocurred";
            }
        }

        public static async Task<int> GetUserIdByEmailPassword(string email, string password)
        {
            try
            {
                using (var ctx = new EFContext())
                {
                    var usr = ctx.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
                    return usr != null ? usr.Id : -1;
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static bool GetUserByEmailPassword(string email, string password)
        {
            try
            {
                using (var ctx = new EFContext())
                {
                    return ctx.Users.Any(u => u.Email == email && u.Password == password);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool UpdatePassword(int userId, string password, string currentPasswrod, string confirmPassword)
        {
            try
            {
                using (var ctx = new EFContext())
                {
                    //find user by id
                    var user = ctx.Users.FirstOrDefault(u => u.Id == userId && u.Password == currentPasswrod);
                    if(user != null && password == confirmPassword)
                    {
                        user.Password = password;
                        ctx.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
