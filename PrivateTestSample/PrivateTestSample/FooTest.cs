using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using NUnit.Framework;
using FooLibrary;

namespace PrivateTestSample
{
    [TestFixture]
    public class FooTest
    {
        [Test]
        public void プライベートメソッドを実行する()
        {
            MethodInfo methodinfo = typeof( Foo ).GetMethod( "FooMethod", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance );

            var foo = new Foo();

            int actual = (int)methodinfo.Invoke( foo, new object[] { 3, 4 } );
            Assert.That( actual, Is.EqualTo( 7 ) );
        }

        [Test]
        public void プライベートな静的メソッドを実行する()
        {
            MethodInfo methodinfo = typeof( Foo ).GetMethod( "StaticFooMethod", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Static );

            var foo = new Foo();

            int actual = (int)methodinfo.Invoke( foo, new object[] { 3, 4 } );
            Assert.That( actual, Is.EqualTo( 12 ) );
        }

        [Test]
        public void プライベートフィールドにアクセスする()
        {
            FieldInfo fieldInfo = typeof( Foo ).GetField( "_value", BindingFlags.NonPublic | BindingFlags.Instance );

            var foo = new Foo();

            int actual = (int)fieldInfo.GetValue( foo );
            Assert.That( actual, Is.EqualTo( 32 ) );

            fieldInfo.SetValue( foo, 31 );
            Assert.That( (int)fieldInfo.GetValue( foo ), Is.EqualTo( 31 ) );
        }

        [Test]
        public void プライベートな静的フィールドにアクセスする()
        {
            FieldInfo fieldInfo = typeof( Foo ).GetField( "_staticValue", BindingFlags.NonPublic | BindingFlags.Static );

            var foo = new Foo();

            int actual = (int)fieldInfo.GetValue( foo );
            Assert.That( actual, Is.EqualTo( 168 ) );

            fieldInfo.SetValue( foo, 777 );
            Assert.That( (int)fieldInfo.GetValue( foo ), Is.EqualTo( 777 ) );
        }

        [Test]
        public void プライベートプロパティにアクセスする()
        {
            PropertyInfo propertyInfo = typeof( Foo ).GetProperty( "FooProperty", BindingFlags.NonPublic | BindingFlags.Instance );

            var foo = new Foo();

            string actual = (string)propertyInfo.GetValue( foo );
            Assert.That( actual, Is.EqualTo( "private property" ) );

            propertyInfo.SetValue( foo, "foo bar baz" );
            Assert.That( (string)propertyInfo.GetValue( foo ), Is.EqualTo( "foo bar baz" ) );
        }

        [Test]
        public void プライベートな静的プロパティにアクセスする()
        {
            PropertyInfo propertyInfo = typeof( Foo ).GetProperty( "StaticFooProperty", BindingFlags.NonPublic | BindingFlags.Static );

            var foo = new Foo();

            string actual = (string)propertyInfo.GetValue( foo );
            Assert.That( actual, Is.EqualTo( "private static property" ) );

            propertyInfo.SetValue( foo, "FooOOO" );
            Assert.That( (string)propertyInfo.GetValue( foo ), Is.EqualTo( "FooOOO" ) );
        }
    }
}
