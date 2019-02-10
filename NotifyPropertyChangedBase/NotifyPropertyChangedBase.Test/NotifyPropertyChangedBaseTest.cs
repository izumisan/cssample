using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace NotifyPropertyChangedBase.Test
{
    [TestFixture]
    public class NotifyPropertyChangedBaseTest
    {
        [Test]
        public void SetPropertyでPropertyChangedが発火されること( [Random( 10 )] int value )
        {
            bool actual = false;

            var foo = new Foo();
            foo.PropertyChanged += ( s, e ) => { actual = true; };

            foo.Value1 = value;
            Assert.That( actual, Is.True );
        }

        [Test]
        public void PropertyChagnedにPropertyNameが設定されていること( [Random( 10 )] int value )
        {
            string actual = string.Empty;

            var foo = new Foo();
            foo.PropertyChanged += ( s, e ) => { actual = e.PropertyName; };

            foo.Value1 = value;
            Assert.That( actual, Is.EqualTo( "Value1" ) );
        }

        [Test]
        public void プロパティ変更時のアクションが実行されること( [Random( 10 )] int value )
        {
            var foo = new Foo();
            foo.Value2 = value;

            Assert.That( foo.Value2, Is.EqualTo( value ) );
            Assert.That( foo.Value3, Is.EqualTo( foo.Value2 + 1 ) );
        }
    }
}
