using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTestTalk
{
    public interface IProfileValidator
    {
        IEnumerable<ValidationResult> Valiate(Profile profile);
    }

    public class StandardProfileValidator : IProfileValidator
    {
        public IEnumerable<ValidationResult> Valiate(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException("profile");
            }

            var results = new List<ValidationResult>();

            if (profile.Type != ProfileType.Defult)
            {
                results.Add(new ValidationResult("Can't validate VIP profiles"));
            }
            else
            {
                if (string.IsNullOrWhiteSpace(profile.Name))
                {
                    results.Add(new ValidationResult("Can't have an empty name"));
                }
            }

            return results;
        }
    }
}