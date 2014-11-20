using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.BDD
{
    public abstract class Spec
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            SpecSetup();

            Given();

            When();
        }

        public virtual void SpecSetup()
        { }

        public abstract void Given();

        public abstract void When();
    }
}