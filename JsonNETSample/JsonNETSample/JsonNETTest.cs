using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        [Test]
        public void Keyにコンマが含まれていてもよい()
        {
            var json = @"{
                ""foo"": ""FOO"",
                ""foo.bar"": 123,
                ""foo.bar.baz"": true
            }";

            var jobj = JsonConvert.DeserializeObject( json ) as JObject;
            Assert.That( jobj.Value<String>( "foo" ), Is.EqualTo( "FOO" ) );
            Assert.That( jobj.Value<int>( "foo.bar" ), Is.EqualTo( 123 ) );
            Assert.That( jobj.Value<bool>( "foo.bar.baz" ), Is.EqualTo( true ) );

            var serialized = JsonConvert.SerializeObject( jobj );
            Assert.That( serialized, Is.EqualTo( "{\"foo\":\"FOO\",\"foo.bar\":123,\"foo.bar.baz\":true}" ) );
        }

        [Test]
        public void JSON文字列にコメントが含まれていてもよい()
        {
            var json = @"{
                // コメント行が含まれていてもデシリアライズできる
                ""foo"": ""FOO"",
                ""foo.bar"": 123,
                /*
                    複数行コメント
                    JSON規格ではコメント行は許容されていないが、VSCodeのsettings.jsonのようなコメント行が含まれていてもシリアライズ可能
                    (ちなみに、拡張子を.jsoncのファイルをVSCodeで開いた場合、コメント行が含まれていてもエラーにならない)
                */
                ""foo.bar.baz"": true
            }";

            var jobj = JsonConvert.DeserializeObject( json ) as JObject;
            Assert.That( jobj.Value<String>( "foo" ), Is.EqualTo( "FOO" ) );
            Assert.That( jobj.Value<int>( "foo.bar" ), Is.EqualTo( 123 ) );
            Assert.That( jobj.Value<bool>( "foo.bar.baz" ), Is.EqualTo( true ) );

            var serialized = JsonConvert.SerializeObject( jobj );
            Assert.That( serialized, Is.EqualTo( "{\"foo\":\"FOO\",\"foo.bar\":123,\"foo.bar.baz\":true}" ) );
        }
    }
}
