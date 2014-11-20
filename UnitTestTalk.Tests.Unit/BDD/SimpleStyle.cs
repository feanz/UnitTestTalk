using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.BDD
{
    [TestFixture]
    public class AccountHasInsufficientFund
    {
        //Common setup could be refactored to a method

        [Test]
        public void Request_more_money_than_in_account_then_the_ATM_should_not_dispense_any_money()
        {
            var card = new Card(true, 10);
            var atm = new Atm(100);

            atm.RequestMoney(card, 20);

            Assert.AreEqual(0, atm.DispenseValue);
        }

        [Test]
        public void Request_more_money_than_in_account_then_the_ATM_should_say_there_are_Insufficient_Funds()
        {
            var card = new Card(true, 10);
            var atm = new Atm(100);

            atm.RequestMoney(card, 20);

            Assert.AreEqual(DisplayMessage.InsufficientFunds, atm.Message);
        }

        [Test]
        public void Request_more_money_than_in_account_then_the_the_Account_Balance_Should_Be_20()
        {
            var card = new Card(true, 10);
            var atm = new Atm(100);

            atm.RequestMoney(card, 20);

            Assert.AreEqual(10, card.AccountBalance);
        }
    }
}