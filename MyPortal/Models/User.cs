﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}