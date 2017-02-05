﻿using ApIosMessenger.EF.Models;
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
    }
}