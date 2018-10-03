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
    public class FooTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.Print( "FooTest::OneTimeSetUp()" );
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.Print( "FooTest::OneTimeTearDown()" );
        }

        [SetUp]
        public void SetUp()
        {
            Debug.Print( "FooTest::SetUp()" );
        }

        [TearDown]
        public void TearDown()
        {
            Debug.Print( "FooTest::TearDown()" );
        }
        
        [Test]
        public void テスト1()
        {
            Debug.Print( "FooTest::テスト1()" );
            Assert.That( true );
        }

        [Test]
        public void テスト2()
        {
            Debug.Print( "FooTest::テスト2()" );
            Assert.That( true );
        }
    }
}
