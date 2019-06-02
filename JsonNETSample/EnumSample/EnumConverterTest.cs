using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Newtonsoft.Json;

namespace EnumSample
{
    [TestFixture]
    public class EnumConverterTest
    {
        /// <summary>
        /// Enum要素のシリアライズ
        /// </summary>
        [Test]
        public void Enum要素のシリアライズ()
        {
            var foo = new Foo
            {
                Month1 = MonthEnum.Mar,
                Month2 = MonthEnum.Mar
            };

            // シリアライズ
            var json = JsonConvert.SerializeObject( foo );
            //=> {"Month1":3,"Month2":"Mar"}
            // 
            // デフォルトでは、Enumは数値でシリアライズされる。
            // StringEnumConverterを指定すると文字列でシリアライズされる

            System.Diagnostics.Debug.Print( json );
        }

        /// <summary>
        /// Enum要素のデシリアライズ
        /// </summary>
        [TestCaseSource( nameof( Enum要素のデシリアライズ_data ) )]
        public void Enum要素のデシリアライズ( string json, Foo expected )
        {
            // デシリアライズ
            var actual = JsonConvert.DeserializeObject<Foo>( json );
            // デシリアライズの場合、
            // StringEnumConverterを指定していなくてもいい感じにデシリアライズされる

            Assert.That( actual.Month1, Is.EqualTo( expected.Month1 ) );
            Assert.That( actual.Month2, Is.EqualTo( expected.Month2 ) );
        }

        private static IEnumerable<object[]> Enum要素のデシリアライズ_data()
        {
            // Enum要素を数値で指定したケース
            yield return new object[] { @"{ ""Month1"": 1, ""Month2"": 3 }", new Foo { Month1 = MonthEnum.Jan, Month2 = MonthEnum.Mar } };

            // Enum要素を文字列で指定したケース
            yield return new object[] { @"{ ""Month1"": ""May"", ""Month2"": ""Jul"" }", new Foo { Month1 = MonthEnum.May, Month2 = MonthEnum.Jul } };

            // Enum要素を文字列（小文字）で指定したケース
            yield return new object[] { @"{ ""Month1"": ""sep"", ""Month2"": ""nov"" }", new Foo { Month1 = MonthEnum.Sep, Month2 = MonthEnum.Nov } };
        }
    }
}
