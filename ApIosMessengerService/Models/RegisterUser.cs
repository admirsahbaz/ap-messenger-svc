﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApIosMessengerService.Models
{
    public class RegisterUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}