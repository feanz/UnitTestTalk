using System;

namespace UnitTestTalk.Workshop.Models
{
    public class Membership
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime LastLogin { get; set; }
    }
}