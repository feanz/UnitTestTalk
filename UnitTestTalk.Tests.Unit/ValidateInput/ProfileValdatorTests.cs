using System;
using System.Linq;
using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.ValidateInput
{
    [TestFixture]
    public class ProfileValdatorTests
    {
        [Test]
        public void Validate_should_throw_argument_exception_if_null_profile_supplied()
        {
            var sut = new StandardProfileValidator();

            Assert.Throws<ArgumentNullException>(() => sut.Valiate(null));
        }

        [Test]
        public void Validate_should_return_one_error_result_if_profile_VIP()
        {
            var sut = new StandardProfileValidator();

            var vipProfile = new Profile
                             {
                                 Type = ProfileType.VIP
                             };

            var actual = sut.Valiate(vipProfile);

            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().ErrorMessage, "Can't validate VIP profiles");
        }

        [Test]
        public void Validate_should_return_error_if_name_is_empty()
        {
            var sut = new StandardProfileValidator();

            var profileWithInvalidName = new Profile
            {
                Type = ProfileType.Defult,
                Name = ""
            };

            var actual = sut.Valiate(profileWithInvalidName);

            Assert.AreEqual(actual.Count(), 1);
            Assert.AreEqual(actual.First().ErrorMessage, "Can't have an empty name");
        }

        [Test]
        public void Validate_should_return_empty_list_if_profile_valid()
        {
            var sut = new StandardProfileValidator();

            var profileWithInvalidName = new Profile
            {
                Type = ProfileType.Defult,
                Name = "Steve"
            };

            var actual = sut.Valiate(profileWithInvalidName);

            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.Count(), 0);
        }
    }
}