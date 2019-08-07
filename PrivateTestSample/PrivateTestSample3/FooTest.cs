using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using FooLibrary;

namespace PrivateTestSample3
{
    using PrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
    using PrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;

    [TestFixture]
    public class FooTest
    {
        [Test]
        public void プライベートメソッドを実行する()
        {
            var foo = new Foo();

            PrivateObject pobj = new PrivateObject( foo );

            int actual = (int)pobj.Invoke( "FooMethod", new object[] { 3, 4, } );
            Assert.That( actual, Is.EqualTo( 7 ) );
        }

        [Test]
        public void プライベートな静的メソッドを実行する()
        {
            PrivateType ptype = new PrivateType( typeof( Foo ) );

            int actual = (int)ptype.InvokeStatic( "StaticFooMethod", new object[] { 3, 4 } );
            Assert.That( actual, Is.EqualTo( 12 ) );
        }

        [Test]
        public void プライベートフィールドにアクセスする()
        {
            var foo = new Foo();

            PrivateObject pobj = new PrivateObject( foo );

            int actual = (int)pobj.GetField( "_value" );
            Assert.That( actual, Is.EqualTo( 32 ) );

            pobj.SetField( "_value", 31 );
            Assert.That( (int)pobj.GetField( "_value" ), Is.EqualTo( 31 ) );
        }

        [Test]
        public void プライベートな静的フィールドにアクセスする()
        {
            PrivateType ptype = new PrivateType( typeof( Foo ) );

            int actual = (int)ptype.GetStaticField( "_staticValue" );
            Assert.That( actual, Is.EqualTo( 168 ) );

            ptype.SetStaticField( "_staticValue", 777 );
            Assert.That( (int)ptype.GetStaticField( "_staticValue" ), Is.EqualTo( 777 ) ); 
        }

        [Test]
        public void プライベートプロパティにアクセスする()
        {
            var foo = new Foo();

            PrivateObject pobj = new PrivateObject( foo );

            string actual = (string)pobj.GetProperty( "FooProperty" );
            Assert.That( actual, Is.EqualTo( "private property" ) );

            pobj.SetProperty( "FooProperty", "foo bar baz" );
            Assert.That( (string)pobj.GetProperty( "FooProperty" ), Is.EqualTo( "foo bar baz" ) );
        }

        [Test]
        public void プライベートな静的プロパティにアクセスする()
        {
            PrivateType ptype = new PrivateType( typeof( Foo ) );

            string actual = (string)ptype.GetStaticProperty( "StaticFooProperty" );
            Assert.That( actual, Is.EqualTo( "private static property" ) );

            ptype.SetStaticProperty( "StaticFooProperty", "FooOOO" );
            Assert.That( (string)ptype.GetStaticProperty( "StaticFooProperty" ), Is.EqualTo( "FooOOO" ) );
        }
    }
}
