using Moq;
using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.Moq
{
    [TestFixture]
    public class MoqTests
    {
        [Test]
        public void UpdateProfile_updates_profiles_lucky_number()
        {
            var existingProfile = new Profile
                                  {
                                      Id = 1,
                                      Name = "Steve"
                                  };

            var profile = new Profile
                          {
                              Id = 1,
                              Name = "Steve",
                              LuckyNumber = 100
                          };

            var mockProfileRepository = new Mock<IProfileRepository>();
            var mockProfileEventHandler = new Mock<IProfileEventHandler>();

            mockProfileRepository.Setup(repository => repository.GetProfile(existingProfile.Id))
                .Returns(existingProfile);

            var sut = new ProfileService(new StandardProfileValidator(), mockProfileRepository.Object, mockProfileEventHandler.Object);

            var actual = sut.UpdateProfile(profile);

            Assert.AreEqual(100, actual.LuckyNumber);

            mockProfileRepository.Verify(repository => repository.UpdateProfile(existingProfile), Times.Once);
        }

        [Test]
        public void GetProfile_when_profile_Vip_event_raised()
        {
            var vipProfile = new Profile
            {
                Id = 1,
                Name = "Steve",
                IsVip = true
                
            };

            var mockProfileRepository = new Mock<IProfileRepository>();
            var mockProfileEventHandler = new Mock<IProfileEventHandler>();

            mockProfileRepository.Setup(repository => repository.GetProfile(It.IsAny<int>()))
                .Returns(vipProfile);

            var sut = new ProfileService(new StandardProfileValidator(), mockProfileRepository.Object, mockProfileEventHandler.Object);

            sut.GetProfile(1);

            mockProfileEventHandler.Verify(handler => handler.VipAccessed(),Times.Once);
        }

        [Test]
        public void GetProfile_when_profile_is_not_Vip_event_is_not_raised()
        {
            var standardProfile = new Profile
            {
                Id = 1,
                Name = "Steve",
                IsVip = false

            };

            var mockProfileRepository = new Mock<IProfileRepository>();
            var mockProfileEventHandler = new Mock<IProfileEventHandler>();

            mockProfileRepository.Setup(repository => repository.GetProfile(It.IsAny<int>()))
                .Returns(standardProfile);

            var sut = new ProfileService(new StandardProfileValidator(), mockProfileRepository.Object, mockProfileEventHandler.Object);

            sut.GetProfile(1);

            mockProfileEventHandler.Verify(handler => handler.VipAccessed(), Times.Never);
        }
    }
}