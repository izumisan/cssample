using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NUnit.Framework;
using Google.Protobuf;

namespace ProtobufSample
{
    [TestFixture]
    public class Class1
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void バイト列へのシリアライズ_デシリアライズ()
        {
            var foo = new Foo
            {
                Id = 777,
                Name = "foo",
                Value = 123.4567,
                Happy = true
            };

            // シリアライズ
            byte[] bytes = foo.ToByteArray();

            // デシリアライズ
            var refoo = Foo.Parser.ParseFrom( bytes );

            Assert.That( refoo, Is.EqualTo( foo ) );
        }

        [Test]
        public void JSONへのシリアライズ()
        {
            var foo = new Foo
            {
                Id = 777,
                Name = "foo",
                Value = 123.4567,
                Happy = true
            };

            // シリアライズ to JSON
            var json = JsonFormatter.Default.Format( foo );

            Assert.That( json, Is.EqualTo( @"{ ""id"": 777, ""name"": ""foo"", ""value"": 123.4567, ""happy"": true }" ) );
        }

        [Test]
        public void JSONのデシリアライズ()
        {
            var json = @"{""id"":777,""name"":""foo"",""value"":123.4567,""happy"":true}";

            // デシリアライズ from JSON
            var foo = JsonParser.Default.Parse<Foo>( json );

            Assert.That( foo, Is.EqualTo( new Foo { Id = 777, Name = "foo", Value = 123.4567, Happy = true } ) );
        }
    }
}
