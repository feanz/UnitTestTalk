using System;

namespace UnitTestTalk.Workshop.Models.Requests
{
    public class ResetPasswordRequest
    {
        public string NewPassword { get; set; }

        public string NewPasswordRepeat { get; set; }

        public Guid PasswordResetToken { get; set; }
    }
}