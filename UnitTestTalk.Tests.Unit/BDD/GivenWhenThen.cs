using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.BDD
{
    [TestFixture]
    public class GivenAccountHasInsufficientFund :Spec
    {
        private Card _card;
        private Atm _atm;

        public override void Given()
        {
            _card = new Card(true, 10);
            _atm = new Atm(100);
        }

        public override void When()
        {
            _atm.RequestMoney(_card, 20);
        }

        public void WhenTheAccountHolderRequests20()
        {
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
        public void Then_the_account_Balance_should_be_20()
        {
            Assert.AreEqual(10, _card.AccountBalance);
        }

        [Test]
        public void Then_the_card_should_be_returned()
        {
            Assert.IsFalse(_atm.CardIsRetained);
        }
    }
}