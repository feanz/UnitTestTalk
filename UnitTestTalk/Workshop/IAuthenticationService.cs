using UnitTestTalk.Workshop.Models.Requests;
using UnitTestTalk.Workshop.Models.Response;

namespace UnitTestTalk.Workshop
{
    public interface IAuthenticationService
    {
        RegisterResponse Register(RegisterRequest request);
        LoginResponse Login(LoginRequest request);
        bool ValidateCredentials(ValidateCredentialsRequest request);
        UpdatePasswordResponse UpdatePassword(UpdatePasswordRequest request);
        UpdateEmailResponse UpdateEmail(UpdateEmailRequest request);
        SendPasswordResetEmailResponse SendPasswordResetEmail(SendPasswordResetEmailRequest request);
        ResetPasswordResponse ResetPassword(ResetPasswordRequest request);
    }
}