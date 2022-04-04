using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Google.Protobuf;

namespace OptionalTrial
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Optionalの確認()
        {
            var foo = new Foo
            {
                Id = 777
            };

            // optional指定したフィールドは、HasXXXプロパティでフィールドの有無を確認できる
            Assert.That( foo.HasName, Is.False );
            Assert.That( foo.Name, Is.Empty );  // empty: sgtringフィールドの既定値

            // 明示的にemptyをセットした場合、HasXXXプロパティはtrueとなる
            foo.Name = string.Empty;
            Assert.That( foo.HasName, Is.True );
            Assert.That( foo.Name, Is.EqualTo( string.Empty ) );

            // ClearXXXメソッドで、フィールドのクリアが可能
            foo.ClearName();
            Assert.That( foo.HasName, Is.False );
            Assert.That( foo.Name, Is.Empty );
        }

        [Test]
        public void Optionalの確認2()
        {
            var foo = new Foo
            {
                Id = 777
            };

            Assert.That( foo.HasValue, Is.False );
            Assert.That( foo.Value, Is.EqualTo( 0.0 ) );  // 0.0: doubleフィールドの既定値

            // 明示的に0.0をセットした場合、HasXXXプロパティはtrueとなる
            foo.Value = 0.0;
            Assert.That( foo.HasValue, Is.True );
            Assert.That( foo.Value, Is.EqualTo( 0.0 ) );

            foo.ClearValue();
            Assert.That( foo.HasValue, Is.False );
            Assert.That( foo.Value, Is.EqualTo( 0.0 ) );
        }
    }
}
