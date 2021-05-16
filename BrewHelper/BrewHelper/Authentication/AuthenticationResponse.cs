﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Authentication
{
    public class AuthenticationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class LoginResponse
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}