using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using MessagePack;

namespace MessagePackSample
{
    class Program
    {
        static void Main( string[] args )
        {
            var foo = new Foo();

            foo.Value1 = 777;
            foo.Value2 = 123.4567;
            foo.Name = "foo";
            foo.ValueList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            foo.Dictionary = new Dictionary<int, string>
            {
                { 1, "foo" },
                { 2, "bar" },
                { 3, "baz" }
            };

            // シリアライズ
            byte[] bytes = MessagePackSerializer.Serialize( foo );

            Console.WriteLine( $"size: {bytes.Count()}" );

            // デシリアライズ
            Foo refoo = MessagePackSerializer.Deserialize<Foo>( bytes );

            Console.WriteLine( refoo.Name );

            // JSON文字列化
            // Keyアトリビュートにint型を指定しているため
            // 各パラメータを配列としたJSON文字列となる
            string json = MessagePackSerializer.ToJson( bytes );

            Console.WriteLine( json );

            Console.ReadLine();
        }
    }
}
