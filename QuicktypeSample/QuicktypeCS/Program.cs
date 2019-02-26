using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace QuicktypeCS
{
    class Program
    {
        static void Main( string[] args )
        {
            // サンプルJSON
            // https://app.quicktype.io/

            var samplejson = @"{
    ""greeting"": ""Welcome to quicktype!"",
    ""instructions"": [
      ""Type or paste JSON here"",
      ""Or choose a sample above"",
      ""quicktype will generate code in your"",
      ""chosen language to parse the sample data""
    ]
}";

            // デシリアライズ
            //------------------------------------------------------------------
            // Welcome.csは自動生成コード
            // （生成されるコードはNewtonsoft.Json用）
            var deserializedObj = QuickType.Welcome.FromJson( samplejson );

            // 確認用デバッグプリント
            Debug.Print( deserializedObj.Greeting );
            foreach ( var element in deserializedObj.Instructions )
            {
                Debug.Print( element );
            }


            // シリアライズ
            //------------------------------------------------------------------
            var obj = new QuickType.Welcome
            {
                Greeting = "foo",
                Instructions = new string[] { "item 0", "item 1", "item 2" }
            };

            var serializedJson = QuickType.Serialize.ToJson( obj );

            Debug.Print( serializedJson );
        }
    }
}
