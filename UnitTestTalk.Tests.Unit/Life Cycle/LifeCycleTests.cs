using System;
using NUnit.Framework;

namespace UnitTestTalk.Tests.Unit
{
    [TestFixture]
    public class LifeCycleTests
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Console.WriteLine("FixtureSetup");
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setup");
        }

        [Test]
        public void TestOne()
        {
            Console.WriteLine("TestOne");
        }

        [Test]
        public void TestTwo()
        {
            Console.WriteLine("TestTwo");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Console.WriteLine("TestFixtureTearDown");
        }
    }
}