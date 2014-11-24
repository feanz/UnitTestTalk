namespace UnitTestTalk.Workshop.Models.Requests
{
    public class ChangePasswordRequest 
    {
        public string Username  { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string PasswordRepeat { get; set; }
    }
}