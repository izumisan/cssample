using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace ByteArraySample
{
    [TestFixture]
    public class ByteArrayTest
    {
        [Test]
        public void LEバイト列を数値に変換する()
        {
            // リトルエンディアンバイト列
            byte[] bytes = new byte[] { 0x01, 0x00, 0x00, 0x00 };
            int actual = BitConverter.ToInt32( bytes, 0 );

            Assert.That( actual, Is.EqualTo( 1 ) );

            bytes = new byte[] { 0x10, 0x00, 0x00, 0x00 };
            actual = BitConverter.ToInt32( bytes, 0 );

            Assert.That( actual, Is.EqualTo( 16 ) );

            bytes = new byte[] { 0x7F, 0x00, 0x00, 0x00 };
            actual = BitConverter.ToInt32( bytes, 0 );

            Assert.That( actual, Is.EqualTo( 127 ) );

            bytes = new byte[] { 0xFF, 0x00, 0x00, 0x00 };
            actual = BitConverter.ToInt32( bytes, 0 );

            Assert.That( actual, Is.EqualTo( 255 ) );

        }

        [Test]
        public void 数値をLEバイト列に変換する()
        {
            Assert.That( BitConverter.GetBytes( 1 ), Is.EqualTo( new byte[] { 0x01, 0x00, 0x00, 0x00 } ) );
            Assert.That( BitConverter.GetBytes( 16 ), Is.EqualTo( new byte[] { 0x10, 0x00, 0x00, 0x00 } ) );
            Assert.That( BitConverter.GetBytes( 127 ), Is.EqualTo( new byte[] { 0x7F, 0x00, 0x00, 0x00 } ) );
            Assert.That( BitConverter.GetBytes( 255 ), Is.EqualTo( new byte[] { 0xFF, 0x00, 0x00, 0x00 } ) );
        }

        [Test]
        public void BEバイト列を数値に変換する()
        {
            // ビッグエンディアンバイト列
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            int actual = BitConverter.ToInt32( bytes.Reverse().ToArray(), 0 );

            Assert.That( actual, Is.EqualTo( 1 ) );

            bytes = new byte[] { 0x00, 0x00, 0x00, 0x7F };
            actual = BitConverter.ToInt32( bytes.Reverse().ToArray(), 0 );

            Assert.That( actual, Is.EqualTo( 127 ) );

            bytes = new byte[] { 0x00, 0x00, 0x00, 0xFF };
            actual = BitConverter.ToInt32( bytes.Reverse().ToArray(), 0 );

            Assert.That( actual, Is.EqualTo( 255 ) );
        }

        [Test]
        public void BEバイト列を数値に変換する2()
        {
            // ビッグエンディアンバイト列
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x01 };
            int actual = BitConverter.ToInt32( bytes, 0 );

            // System.Net.IPAddress.NetworkToHostOrderで
            // ネットワークバイトオーダー（ビッグエンディアン）を
            // ホストオーダー（windows, リトルエンディアン）に変換する
            actual = System.Net.IPAddress.NetworkToHostOrder( actual );

            Assert.That( actual, Is.EqualTo( 1 ) );
        }
    }
}
