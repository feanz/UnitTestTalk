using NUnit.Framework;
using UnitTestTalk.Tests.Unit.BDD;

namespace UnitTestTalk.Tests.Unit.ExpectedOutput
{
    [TestFixture]
    public class AccountHolderWithdrawsCash
    {
        [Test]
        public void Request_money_in_account_then_atm_dispenses_cash()
        {
            //Arrange 
            var card = new Card(enabled: true, accountBalance:100);
            var atm = new Atm(1000);

            //Act
            atm.RequestMoney(card, 20);

            //Assert
            Assert.AreEqual(atm.DispenseValue, 20);
        }

        [Test]
        public void Request_money_on_disabled_card_then_atm_retains_card()
        {
            //Arrange 
            var card = new Card(enabled: false, accountBalance: 100);
            var atm = new Atm(1000);

            //Act
            atm.RequestMoney(card, 20);

            //Assert
            Assert.AreEqual(true, atm.CardIsRetained);
        }

        [Test]
        [TestCase(20, DisplayMessage.None)]
        [TestCase(50, DisplayMessage.None)]
        [TestCase(100, DisplayMessage.None)]
        [TestCase(101, DisplayMessage.InsufficientFunds)]
        public void Request_money_displays_appropriate_message(int amountRequested, DisplayMessage messge)
        {
            //Arrange 
            var card = new Card(enabled: true, accountBalance: 100);
            var atm = new Atm(1000);

            //Act
            atm.RequestMoney(card, amountRequested);

            //Assert
            Assert.AreEqual(messge, atm.Message);
        }
    }
}