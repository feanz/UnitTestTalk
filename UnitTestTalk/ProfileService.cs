using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTestTalk
{
    public class ProfileService
    {
        private readonly IProfileValidator _profileValidator;
        private readonly IProfileRepository _profileRepository;
        private readonly IProfileEventHandler _profileEventHandler;

        public ProfileService(IProfileValidator profileValidator, IProfileRepository profileRepository, IProfileEventHandler profileEventHandler)
        {
            _profileValidator = profileValidator;
            _profileRepository = profileRepository;
            _profileEventHandler = profileEventHandler;
        }

        public Profile GetProfile(int id)
        {
            var profile = _profileRepository.GetProfile(id);

            if (profile.IsVip)
            {
                _profileEventHandler.VipAccessed();
            }

            return profile;
        }

        public Profile CreateProfile(Profile profile)
        {
            var validationResults = _profileValidator.Valiate(profile);

            var validProfile = !validationResults.Any();

            if (!validProfile)
            {
                throw new ValidationException("Profile was invalid");
            }

            var newProfile = _profileRepository.CreateProfile(profile);
            return newProfile;
        }

        public Profile UpdateProfile(Profile profile)
        {
            var existingProfile = _profileRepository.GetProfile(profile.Id);

            if (existingProfile == null)
            {
                throw new Exception("No profile exists for that Id");
            }

            existingProfile.LuckyNumber = profile.LuckyNumber;

            _profileRepository.UpdateProfile(existingProfile);

            return existingProfile;
        }
    }
}