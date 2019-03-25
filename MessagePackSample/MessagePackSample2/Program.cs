using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessagePack;

namespace MessagePackSample2
{
    class Program
    {
        static void Main( string[] args )
        {
            var foo = new Foo
            {
                Id = 777,
                Name = "FOO",
                Bar = new Bar
                {
                    Id = 7,
                    Name = "BAR",
                    Value = 123.4567
                },
                Value = 123
            };

            // シリアライズ
            byte[] bytes = MessagePackSerializer.Serialize( foo );

            Console.WriteLine( $"size: { bytes.Count() }" );

            // デシリアライズ
            Foo foo2 = MessagePackSerializer.Deserialize<Foo>( bytes );

            // JSON文字列化
            // Keyアトリビュートにstring型を指定しているため
            // "key: value"形式のJSON文字列となる
            string json = MessagePackSerializer.ToJson( bytes );

            Console.WriteLine( json );

            Console.ReadLine();
        }
    }
}
