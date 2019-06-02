using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace SerializeFormatSample
{
    [TestFixture]
    public class SerializeFormatTest
    {
        [Test]
        public void デフォルト設定でシリアライズ()
        {
            var foo = new Foo
            {
                Name = "Foo",
                Value = 1,
                Lucky = true,
                Month = MonthEnum.Jan
            };

            // シリアライズ
            var json = JsonConvert.SerializeObject( foo );
            //=> {"Name":"Foo","Value":1,"Lucky":true,"Month":1}

            System.Diagnostics.Debug.Print( json );
        }

        [Test]
        public void インデントありでシリアライズ()
        {
            var foo = new Foo
            {
                Name = "Foo",
                Value = 3,
                Lucky = true,
                Month = MonthEnum.Mar
            };

            // 整形してシリアライズ
            var json = JsonConvert.SerializeObject( foo, Formatting.Indented );
            /* =>
            {
              "Name": "Foo",
              "Value": 3,
              "Lucky": true,
              "Month": 3
            }
            */

            System.Diagnostics.Debug.Print( json );
        }

        [Test]
        public void JsonSerializerSettingsを指定してシリアライズ()
        {
            var foo = new Foo
            {
                Name = "Foo",
                Value = 5,
                Lucky = true,
                Month = MonthEnum.May
            };

            var settings = new JsonSerializerSettings
            {
                // プロパティ名をキャメルケースで出力
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                // Enumは文字列で出力
                Converters = new List<JsonConverter> { new StringEnumConverter() },
                // インデントありで出力
                Formatting = Formatting.Indented
            };

            // シリアライズ
            var json = JsonConvert.SerializeObject( foo, settings );
            /* =>
            {
              "name": "Foo",
              "value": 5,
              "lucky": true,
              "month": "May"
            }
            */

            System.Diagnostics.Debug.Print( json );
        }
    }
}
