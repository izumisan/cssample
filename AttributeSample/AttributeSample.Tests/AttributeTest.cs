using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using NUnit.Framework;

namespace AttributeSample.Tests
{
    [TestFixture]
    public class AttributeTest
    {
        [Test]
        public void FooAttributeの値を取得する()
        {
            // FooTestClassクラスの属性を取得する
            Attribute[] attributes = Attribute.GetCustomAttributes( typeof( FooTestClass ) );

            Assert.That( attributes.Count(), Is.EqualTo( 1 ) );

            var fooattr = attributes.First() as FooAttribute;

            Assert.That( fooattr.Name, Is.EqualTo( "foo" ) );
        }

        [Test]
        public void BarAttributeの値を取得する()
        {
            var attributes = Attribute.GetCustomAttributes( typeof( BarTestClass ) );

            // BarAttributeは複数指定できる
            Assert.That( attributes.Count(), Is.EqualTo( 2 ) );

            var bar1 = attributes.Select( x => x as BarAttribute ).First( x => x.Name == "bar1" );
            Assert.That( bar1.Message, Is.EqualTo( "めっせーじ1" ) );
            Assert.That( bar1.Value, Is.EqualTo( 31 ) );
            Assert.That( bar1.Lucky, Is.True );

            var bar2 = attributes.Select( x => x as BarAttribute ).First( x => x.Name == "bar2" );
            Assert.That( bar2.Message, Is.EqualTo( "めっせーじ2" ) );
            Assert.That( bar2.Value, Is.EqualTo( 32 ) );
            Assert.That( bar2.Lucky, Is.True );
        }

        [Test]
        public void BarAttributeはサブクラスにも適用される()
        {
            var attributes = Attribute.GetCustomAttributes( typeof( BarDerivedTestClass ) );

            Assert.That( attributes.Count(), Is.EqualTo( 2 ) );
            Assert.That( attributes.All( x => x.GetType() == typeof( BarAttribute ) ), Is.True );
        }

        [Test]
        public void BazAttributeを取得する()
        {
            var classAttribute = Attribute.GetCustomAttributes( typeof( BazTestClass ) );
            Assert.That( classAttribute.Count(), Is.Zero );

            MethodInfo method = typeof( BazTestClass ).GetMethods().First( x => x.Name.Equals( "DoSomething" ) );

            // MethodInfoのGetCustomAttributes()により、メソッドの属性を取得する
            var methodAttribute = method.GetCustomAttributes();

            Assert.That( methodAttribute.Count(), Is.EqualTo( 1 ) );
        }
    }
}
