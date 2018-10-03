using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NUnit.Framework;

namespace NUnitAttribute
{
    [TestFixture]
    public class BarTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.Print( "BarTest::OneTimeSetUp()" );
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.Print( "BarTest::OneTimeTearDown()" );
        }

        [SetUp]
        public void SetUp()
        {
            Debug.Print( "BarTest::SetUp()" );
        }

        [TearDown]
        public void TearDown()
        {
            Debug.Print( "BarTest::TearDown()" );
        }

        [Test]
        public void テスト1()
        {
            Debug.Print( "BarTest::テスト1()" );
            Assert.That( true );
        }

        [Test]
        public void テスト2()
        {
            Debug.Print( "BarTest::テスト2()" );
            Assert.That( true );
        }
    }
}
