##AuthenticationService Requirements 

Add test coverage for the AuthenticationService found in UnitTestTalk\Workshop.  All dependecies will need to be mocked. Some method are not yet implemented you will need to implement these method in a TDD approach.  No code should be added before you have a failing test, do the minimum amount of work to get your test to pass then add more tests.    

##Public Functions

* RegisterResponse Register(RegisterRequest request)
* LoginResponse Login(LoginRequest request)
* bool ValidateCredentials(ValidateCredentialsRequest request)
* UpdatePasswordResponse UpdatePassword(UpdatePasswordRequest request)
* UpdateEmailResponse UpdateEmail(UpdateEmailRequest request)
* SendPasswordResetEmailResponse SendPasswordResetEmail(SendPasswordResetEmailRequest request)
* ResetPasswordResponse ResetPassword(ResetPasswordRequest request)

## `Register`

* Should throw exception if request is null
* Should validate 'Username' is supplied
* Should validate 'Password' is supplied
* Should validate 'Email' is supplied
* Should validate 'Password' and 'RepeatPassword' match
* Return error response if request is invalid
* IHashingService is called to create password hash  
* IMembershipRepository is called to create membership
* A RegistrationEvent is published using the IEventHandler
* Response Registered property set to true if membership created

## `Login`

* Should throw exception if request is null 
* Should validate 'Username' is supplied
* Should validate 'Password' is supplied
* Return error response if request is invalid
* IMembershipRepository is called to get existing user 
* Return error response if user does not exist
* IHashingService is called to create password hash
* Return error response if password invalid  
* Updated last login date if password hashes match
* IMembershipRepository is called to update membership
* A LoginEvent is published using the IEventHandler
* Response 'ValidLogin' property set to true if login successful 

## `ValidateCredentials`

* Should throw exception if request is null* 
* Should validate 'Username' is supplied
* Should validate 'CurrentPassword' is supplied
* Should validate 'NewPassword' is supplied
* Should validate 'PasswordRepeat' is supplied
* Should validate 'NewPassword' and 'PasswordRepeat' match
* Return error response if request is invalid
* IMembershipRepository is called to get existing user 
* Return error response if user does not exist
* IHashingService is called to create password hash
* Return false if password is invalid  
* Return true if password is valid 

## `UpdatePassword`

* Should throw exception if request is null
* Should validate 'Username' is supplied
* Should validate 'Password' is supplied
* Return error response if request is invalid
* IMembershipRepository is called to get existing user 
* Return error response if user does not exist
* IHashingService is called to create password hash
* Return error response if password invalid  
* IHashingService is called again to create hash for new password
* Membership 'PasswordHash' is set to new password
* IMembershipRepository is called to update membership
* Response 'PasswordUpdated' property set to true if successful 

## `UpdateEmail`

* Should throw exception if request is null* 
* Should validate 'Username' is supplied
* Should validate 'NewEmail' is supplied
* Return error response if request is invalid
* IMembershipRepository is called to get existing user 
* Return error response if user does not exist  
* Membership 'Email' is updated to new email
* IMembershipRepository is called to update membership
* Response 'EmailUpdated' property set to true if successful 

## `SendPasswordResetEmail`

* Should throw exception if request is null* 
* Should validate 'Username' is supplied
* Return error response if request is invalid
* IMembershipRepository is called to get existing user 
* Return error response if user does not exist  
* IPasswordService is called passing in username
* Response 'PasswordEmailSent' property set to true if successful

## `ResetPassword`

* Should throw exception if request is null*
* Should validate 'Username' is supplied 
* Should validate 'NewPassword' is supplied
* Should validate 'NewPasswordRepeat' is supplied
* Should validate 'PasswordResetToken' is supplied
* Should validate 'NewPassword' and 'PasswordRepeat' match
* Return error response if request is invalid
* IMembershipRepository is called to get existing user 
* Return error response if user does not exist  
* IPasswordService is called passing to validate PasswordResetToken supplied
* If token valid IHashingService is called to generate new password hash
* Return error response if token is invalid 
* Membership 'PasswordHash' is updated to new hash  
* IMembershipRepository is called to update membership
* Response 'PasswordReset' property set to true if successful  
