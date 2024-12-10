using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortal.Models
{
    public class UserAccount
    {
        public int UserId { get; set; }          // Auto-generated ID
        public string FullName { get; set; }     // Full name
        public string Email { get; set; }        // User's email
        public string Password { get; set; }     // Password (hashed)
        public string PhoneNumber { get; set; }  // User's phone number
        public DateTime CreatedAt { get; set; }  // Date account was created
    }
}