using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.BDD
{
    [TestFixture]
    public class WhenAccountHasInsufficientFund
    {
        private Card _card;
        private Atm _atm;

        [SetUp]
        public void AccountHolder_requests_20()
        {
            _card = new Card(true, 10);
            _atm = new Atm(100);

            _atm.RequestMoney(_card, 20);
        }

        [Test]
        public void Then_the_ATM_should_not_dispense_any_Money()
        {
            Assert.AreEqual(0, _atm.DispenseValue);
        }

        [Test]
        public void Then_the_ATM_should_say_there_are_Insufficient_Funds()
        {
            Assert.AreEqual(DisplayMessage.InsufficientFunds, _atm.Message);
        }

        [Test]
        public void Then_the_Account_Balance_Should_Be_20()
        {
            Assert.AreEqual(10, _card.AccountBalance);
        }
    }
}