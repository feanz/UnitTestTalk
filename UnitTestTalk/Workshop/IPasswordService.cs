using System;

namespace UnitTestTalk.Workshop
{
    public interface IPasswordService
    {
        void SendPasswordResetEmail(string username);

        bool ValidatePasswordResetToken(Guid token);
    }
}