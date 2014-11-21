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
    public class AuthenticationService
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

            }

            response.Errors = validationErrors;

            return response;
        }

        public bool ValidateCredentials(ValidateCredentialsRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var valid = false;

            return valid;
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");

            var response = new ChangePasswordResponse();

            var validationErrors = ValidateRequest(request)
              .ToList();

            if (!validationErrors.Any())
            {

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

            }

            response.Errors = validationErrors;

            return response;
        }

        private IEnumerable<ValidationResult> ValidateRequest(RegisterRequest response)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(LoginRequest response)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(ValidateCredentialsRequest response)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(ChangePasswordRequest response)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(ResetPasswordRequest response)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<ValidationResult> ValidateRequest(UpdateEmailRequest response)
        {
            throw new NotImplementedException();
        }
    }
}