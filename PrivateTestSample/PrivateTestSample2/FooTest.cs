using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FooLibrary;

namespace PrivateTestSample2
{
    [TestClass]
    public class FooTest
    {
        [TestMethod]
        public void プライベートメソッドを実行する()
        {
            var foo = new Foo();

            PrivateObject pobj = new PrivateObject( foo );

            int actual = (int)pobj.Invoke( "FooMethod", new object[] { 3, 4, } );
            Assert.AreEqual( 7, actual );
        }

        [TestMethod]
        public void プライベートな静的メソッドを実行する()
        {
            PrivateType ptype = new PrivateType( typeof( Foo ) );

            int actual = (int)ptype.InvokeStatic( "StaticFooMethod", new object[] { 3, 4 } );
            Assert.AreEqual( 12, actual );
        }

        [TestMethod]
        public void プライベートフィールドにアクセスする()
        {
            var foo = new Foo();

            PrivateObject pobj = new PrivateObject( foo );

            int actual = (int)pobj.GetField( "_value" );
            Assert.AreEqual( 32, actual );

            pobj.SetField( "_value", 31 );
            Assert.AreEqual( 31, (int)pobj.GetField( "_value" ) );
        }

        [TestMethod]
        public void プライベートな静的フィールドにアクセスする()
        {
            PrivateType ptype = new PrivateType( typeof( Foo ) );

            int actual = (int)ptype.GetStaticField( "_staticValue" );
            Assert.AreEqual( 168, actual );

            ptype.SetStaticField( "_staticValue", 777 );
            Assert.AreEqual( 777, (int)ptype.GetStaticField( "_staticValue" ) );
        }

        [TestMethod]
        public void プライベートプロパティにアクセスする()
        {
            var foo = new Foo();

            PrivateObject pobj = new PrivateObject( foo );

            string actual = (string)pobj.GetProperty( "FooProperty" );
            Assert.AreEqual( "private property", actual );

            pobj.SetProperty( "FooProperty", "foo bar baz" );
            Assert.AreEqual( "foo bar baz", (string)pobj.GetProperty( "FooProperty" ) );
        }

        [TestMethod]
        public void プライベートな静的プロパティにアクセスする()
        {
            PrivateType ptype = new PrivateType( typeof( Foo ) );

            string actual = (string)ptype.GetStaticProperty( "StaticFooProperty" );
            Assert.AreEqual( "private static property", actual );

            ptype.SetStaticProperty( "StaticFooProperty", "FooOOO" );
            Assert.AreEqual( "FooOOO", (string)ptype.GetStaticProperty( "StaticFooProperty" ) );
        }
    }
}
