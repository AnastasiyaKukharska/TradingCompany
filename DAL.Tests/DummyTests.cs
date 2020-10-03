using NUnit.Framework;
using System;

namespace DAL.Tests
{
    
    [TestFixture]
    public class DummyTests
    {
        [OneTimeSetUp]
        public void SetupFixture()
        {
            Console.WriteLine("SetupFixture");
        }

        [SetUp]
        public void SetupTest()
        {
            Console.WriteLine("SetupTest");
        }

        [OneTimeTearDown]
        public void TearDownFixture()
        {
            Console.WriteLine("TearDownFixture");
        }

        [TearDown]
        public void TearDownTest()
        {
            Console.WriteLine("TearDownTest");
        }

        [Test]
        public void DummyTest()
        {
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void FailingTest()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
