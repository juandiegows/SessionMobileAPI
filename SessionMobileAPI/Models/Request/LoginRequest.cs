﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionMobileAPI.Models
{
    public class LoginRequest
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}