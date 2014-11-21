namespace UnitTestTalk.Workshop.Models.Requests
{
    public class RegisterRequest
    {
        public string Password { get; set; }

        public string RepeatPassword { get; set; }
        
        public string Username { get; set; }

        public string Email { get; set; }
    }
}