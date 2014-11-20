using NUnit.Framework;
using UnitTestTalk.Tests.Unit.BDD;

namespace UnitTestTalk.Tests.Unit.ExpectedOutput
{
    [TestFixture]
    public class AccountHolderWithdrawsCash
    {
        [Test]
        public void Request_money_in_account_cash_is_dispensed()
        {
            //Arrange 
            var card = new Card(true, 100);
            var atm = new Atm(1000);

            //Act
            atm.RequestMoney(card, 20);

            //Assert
            Assert.AreEqual(atm.DispenseValue, 20);
        }

        [Test]
        public void Request_money_on_disabled_card()
        {
            //Arrange 
            var card = new Card(false, 100);
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
        public void Request_money_display_appropraite_message(int amountRequested, DisplayMessage messge)
        {
            //Arrange 
            var card = new Card(true, 100);
            var atm = new Atm(1000);

            //Act
            atm.RequestMoney(card, amountRequested);

            //Assert
            Assert.AreEqual(messge, atm.Message);
        }
    }
}