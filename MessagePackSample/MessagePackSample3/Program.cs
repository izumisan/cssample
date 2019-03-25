using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MessagePack;

namespace MessagePackSample3
{
    class Program
    {
        static void Main( string[] args )
        {
            {
                Console.WriteLine( "--- object type" );

                var source = new object[] { 1, 1.23, "foo", new object[] { 1, 2, 3 } };

                // object型のシリアライズ
                var bytes = MessagePackSerializer.Serialize( source );

                Console.WriteLine( $"size: { bytes.Count() }" );

                // デシリアライズ
                var deserialized = MessagePackSerializer.Deserialize<object[]>( bytes );

                // JSON化
                Console.WriteLine( MessagePackSerializer.ToJson( bytes ) );
            }

            {
                Console.WriteLine( "--- dynamic type" );

                var foo = new Foo { Id = 777, Name = "foo", Value = 1.23 };

                // 普通にシリアライズ
                var bytes = MessagePackSerializer.Serialize( foo );

                // dynamicオブジェクトとしてデシリアライズ
                var dynamicObject = MessagePackSerializer.Deserialize<dynamic>( bytes );

                Console.WriteLine( $"Id = { dynamicObject["Id"] }" );
                Console.WriteLine( $"Name = { dynamicObject["Name"] }" );
                Console.WriteLine( $"Value = { dynamicObject["Value"] }" );

                // JSON化
                Console.WriteLine( MessagePackSerializer.ToJson( bytes ) );
            }

            {
                Console.WriteLine("--- anonymous type");

                // 匿名型オブジェクト
                var anonymous = new { Id = 777, Name = "foo", Value = 1.23 };

                // 匿名型オブジェクトのシリアライズ
                var bytes = MessagePackSerializer.Serialize( anonymous );

                // dynamicとしてデシリアライズ
                var dynamicObject = MessagePackSerializer.Deserialize<dynamic>( bytes );

                Console.WriteLine( $"Id = { dynamicObject["Id"] }" );
                Console.WriteLine( $"Name = { dynamicObject["Name"] }" );
                Console.WriteLine( $"Value = { dynamicObject["Value"] }" );

                // JSON化
                Console.WriteLine( MessagePackSerializer.ToJson( bytes ) );
            }

            Console.ReadLine();
        }
    }
}
