using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApIosMessengerService.Models
{
    public class UpdatePasswordModel
    {
        public string Password { get; set; }
        public string CurrentPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}