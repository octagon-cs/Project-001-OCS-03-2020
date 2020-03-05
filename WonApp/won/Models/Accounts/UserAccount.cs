using System;
using System.Collections.Generic;
using System.Text;

namespace won.Models.Accounts
{
    public class UserAccount
    {
        public int IdUsers { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }
    }
}
