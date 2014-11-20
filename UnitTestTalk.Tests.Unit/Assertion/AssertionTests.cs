using System;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit.Assertion
{
    [TestFixture]
    public class AssertionTests
    {
        [Test]
        public void AreNotEqual()
        {
            Assert.AreNotEqual(1, 2);
        }

        [Test]
        public void AreEqual()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void AreNotSame()
        {
            var one = new object();

            var two = new object();

            Assert.AreNotSame(one, two);
        }

        [Test]
        public void AreSame()
        {
            var one = new object();

            var two = one;

            Assert.AreSame(one, two);
        }

        [Test]
        public void Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                                            {
                                                throw new ArgumentException();
                                            });
        }

        [Test]
        public void DoesNotThrow()
        {
            Assert.DoesNotThrow(() => Console.WriteLine("No exception here"));
        }

        [Test]
        public void Contains()
        {
            var list = new[] { "one", "two", "three" };

            Assert.Contains("one", list);
        }

        [Test]
        public void False()
        {
            Assert.False(2 + 2 == 5);
        }

        [Test]
        public void True()
        {
            Assert.True(2 + 2 == 4);
        }

        [Test]
        public void Null()
        {
            Assert.IsNull(null);
        }

        [Test]
        public void IsInstanceOf()
        {
            var customerService = new DumbCustomerService();
            Assert.IsInstanceOf<Customer>(customerService.GetProfile());
        }

        [Test]
        public void That()
        {
            var somestring = "Some string value";
            Assert.That(somestring, Is.InstanceOf<string>().
                And.Not.Null.
                And.Not.Empty.
                And.Length.InRange(1,100));
        }

        [Test]
        public void Should()
        {
            string actual = "ABCDEFGHI";
            actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
        }
    }
}