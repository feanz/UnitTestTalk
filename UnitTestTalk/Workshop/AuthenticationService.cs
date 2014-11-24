using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using UnitTestTalk.Workshop.Models;
using UnitTestTalk.Workshop.Models.Events;
using UnitTestTalk.Workshop.Models.Requests;
using UnitTestTalk.Workshop.Models.Response;

namespace UnitTestTalk.Workshop
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IHashingService _hashingService;
        private readonly IEventHandler _eventhandler;

        public AuthenticationService(IMembershipRepository membershipRepository,
            IHashingService hashingService,
            IEventHandler eventhandler)
        {
            _membershipRepository = membershipRepository;
            _hashingService = hashingService;
            _eventhandler = eventhandler;
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new RegisterResponse();

            var validationErrors = ValidateRequest(request)
                .ToList();

            if (!validationErrors.Any())
            {
                var passwordHash = _hashingService.Hash(request.Password);
                _membershipRepository.Create(new Membership
                {
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = passwordHash
                });

                _eventhandler.Publish(new RegistrationEvent
                {
                    Username = request.Username
                });

                response.Registered = true;
            }

            response.Errors = validationErrors;

            return response;
        }

        public LoginResponse Login(LoginRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new LoginResponse();

            var validationErrors = ValidateRequest(request)
                .ToList();

            if (!validationErrors.Any())
            {
                var membership = _membershipRepository.Get(request.Username);

                if (membership == null)
                {
                    validationErrors.Add(new ValidationResult("User does not exist"));
                }
                else
                {
                    var passwordHash = _hashingService.Hash(request.Password);

                    if (passwordHash == membership.PasswordHash)
                    {
                        membership.LastLogin = DateTime.UtcNow;
                        _membershipRepository.Update(membership);

                        _eventhandler.Publish(new LoginEvent
                        {
                            Username = membership.Username
                        });

                        response.ValidLogin = true;
                    }
                    else
                    {
                        validationErrors.Add(new ValidationResult("Password username combination invalid"));
                    }
                }
            }

            response.Errors = validationErrors;

            return response;
        }

        public bool ValidateCredentials(ValidateCredentialsRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var valid = false;

            var validationErrors = ValidateRequest(request)
                .ToList();

            if (!validationErrors.Any())
            {
                var membership = _membershipRepository.Get(request.Username);

                if (membership == null)
                {
                    validationErrors.Add(new ValidationResult("User does not exist"));
                }
                else
                {
                    var passwordHash = _hashingService.Hash(request.Password);

                    if (passwordHash == membership.PasswordHash)
                    {
                        valid = true;
                    }
                }
            }

            return valid;
        }

        public UpdatePasswordResponse UpdatePassword(UpdatePasswordRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new UpdatePasswordResponse();

            var validationErrors = ValidateRequest(request)
              .ToList();

            if (!validationErrors.Any())
            {
                var membership = _membershipRepository.Get(request.Username);

                if (membership == null)
                {
                    validationErrors.Add(new ValidationResult("User does not exist"));
                }
                else
                {
                    var passwordHash = _hashingService.Hash(request.CurrentPassword);

                    if (passwordHash == membership.PasswordHash)
                    {
                        var newPassword = _hashingService.Hash(request.NewPassword);

                        membership.PasswordHash = newPassword;

                        _membershipRepository.Update(membership);

                        response.PasswordUpdated = true;
                    }
                }
            }

            response.Errors = validationErrors;

            return response;
        }

        public UpdateEmailResponse UpdateEmail(UpdateEmailRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new UpdateEmailResponse();

            var validationErrors = ValidateRequest(request)
              .ToList();

            if (!validationErrors.Any())
            {
                var membership = _membershipRepository.Get(request.Username);

                if (membership == null)
                {
                    validationErrors.Add(new ValidationResult("User does not exist"));
                }
                else
                {
                    membership.Email = request.NewEmail;
                    response.EmailUpdated = true;
                }
            }

            response.Errors = validationErrors;

            return response;
        }

        public SendPasswordResetEmailResponse SendPasswordResetEmail(SendPasswordResetEmailRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new SendPasswordResetEmailResponse();

            var validationErrors = ValidateRequest(request)
              .ToList();

            if (!validationErrors.Any())
            {
                //todo implement code
                throw new NotImplementedException();
            }

            response.Errors = validationErrors;

            return response;
        }

        public ResetPasswordResponse ResetPassword(ResetPasswordRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new ResetPasswordResponse();

            var validationErrors = ValidateRequest(request)
              .ToList();

            if (!validationErrors.Any())
            {
                //todo implement code
                throw new NotImplementedException();
            }

            response.Errors = validationErrors;

            return response;
        }

        private IEnumerable<ValidationResult> ValidateRequest(RegisterRequest request)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                errors.Add(new ValidationResult("No username provided"));
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                errors.Add(new ValidationResult("No password provided"));
            }

            if (string.IsNullOrWhiteSpace(request.RepeatPassword))
            {
                errors.Add(new ValidationResult("No repeat password provided"));
            }

            if (request.Password != request.RepeatPassword)
            {
                errors.Add(new ValidationResult("Password and repeat do not match"));
            }

            return errors;
        }

        private IEnumerable<ValidationResult> ValidateRequest(LoginRequest request)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                errors.Add(new ValidationResult("No username provided"));
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                errors.Add(new ValidationResult("No password provided"));
            }

            return errors;
        }

        private IEnumerable<ValidationResult> ValidateRequest(ValidateCredentialsRequest request)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                errors.Add(new ValidationResult("No username provided"));
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                errors.Add(new ValidationResult("No password provided"));
            }

            return errors;
        }

        private IEnumerable<ValidationResult> ValidateRequest(UpdatePasswordRequest request)
        {
            //todo implement this to the required spec
            throw new NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(UpdateEmailRequest request)
        {
            //todo implement this to the required spec
            throw new NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(ResetPasswordRequest request)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                errors.Add(new ValidationResult("No new password provided"));
            }

            if (string.IsNullOrWhiteSpace(request.NewPasswordRepeat))
            {
                errors.Add(new ValidationResult("No new password repeat provided"));
            }

            if (request.NewPassword != request.NewPasswordRepeat)
            {
                errors.Add(new ValidationResult("Password and repeat do not match"));
            }

            return errors;
        }

        private IEnumerable<ValidationResult> ValidateRequest(SendPasswordResetEmailRequest request)
        {
            var errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                errors.Add(new ValidationResult("No username provided"));
            }

            return errors;
        }
    }
}