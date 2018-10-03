using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NUnit.Framework;

namespace NUnitAttribute
{
    [SetUpFixture]
    public class SetUpFixtureClass
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.Print( "SetUpFixtureClass::OneTimeSetUp()" );
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.Print( "SetUpFixtureClass::OneTimeTearDown()" );
        }
    }
}
