using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using NUnit.Framework;

namespace JsonNETSample
{
    [TestFixture]
    public class JsonNETTest
    {
        [Test]
        public void シリアライズtoJSON()
        {
            var foo = new Foo
            {
                Name = "Foo 32",
                Value = 32,
                Lucky = true
            };

            // シリアライズ
            string json = JsonConvert.SerializeObject( foo );  // => {"name":"Foo 32","value":32,"lucky":true}

            System.Diagnostics.Debug.Print( json );
        }
        
        [Test]
        public void デシリアライズfromJSON()
        {
            string json = @"{ ""name"": ""foo"", ""value"": 168, ""lucky"": true}";

            // デシリアライズ
            var foo = JsonConvert.DeserializeObject<Foo>( json );

            Assert.That( foo.Name, Is.EqualTo( "foo" ) );
            Assert.That( foo.Value, Is.EqualTo( 168 ) );
            Assert.That( foo.Lucky, Is.True );
        }
    }
}
