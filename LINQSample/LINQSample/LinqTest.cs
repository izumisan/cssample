using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NUnit.Framework;

namespace LINQSample
{
    [TestFixture]
    public class LinqTest
    {
        [Test]
        [Category( "要素の取得" )]
        public void Singleは条件を満たす唯一の要素を返す()
        {
            var source = new List<int> { -1, 0, 1, 2, 3 };
            Assert.That( source.Single( x => x < 0 ), Is.EqualTo( -1 ) );
        }

        [Test]
        [Category( "要素の取得" )]
        public void Singleは条件を満たす要素が複数の場合は例外となる()
        {
            var source = Enumerable.Range( 0, 10 );
            Assert.That( () => source.Single( x => x % 2 == 0 ), Throws.Exception.TypeOf<InvalidOperationException>() );
        }

        [Test]
        [Category( "複数要素の取得" )]
        public void Whereは条件を満たす要素を全て返す()
        {
            var source = new List<int> { 1, 3, 5, 7, 9, 8, 6, 4, 2 };

            var actual = source.Where( x => x < 5 );  // => { 1, 3, 4, 2 }

            var expected = new List<int> { 1, 2, 3, 4 };

            Assert.That( actual, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "複数要素の取得" )]
        public void Distinctは重複を除いたシーケンスを返す()
        {
            var source = new List<int> { 1, 2, 3, 4, 5, 1, 3, 5 };

            var actual = source.Distinct();  // => { 1, 2, 3, 4, 5 }

            var expected = new List<int> { 1, 2, 3, 4, 5 };

            Assert.That( actual, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "複数要素の取得" )]
        public void Skipは先頭から指定した数の要素を除いたシーケンスを返す()
        {
            var source = Enumerable.Range( 0, 10 );

            var actual = source.Skip( 7 );

            var expected = new List<int> { 7, 8, 9 };

            Assert.That( actual, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "複数要素の取得" )]
        public void SkipWhileは先頭から指定条件を満たす要素を除いたシーケンスを返す()
        {
            var source = Enumerable.Range( 0, 10 );

            var actual = source.SkipWhile( x => x < 7 );

            var expected = new List<int> { 7, 8, 9 };

            Assert.That( actual, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "複数要素の取得" )]
        public void Takeは先頭から指定した数の要素のシーケンスを返す()
        {
            var source = Enumerable.Range( 0, 10 );

            var actual = source.Take( 3 );

            var expected = new List<int> { 0, 1, 2 };

            Assert.That( actual, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "複数要素の取得" )]
        public void TakeWhileは先頭から指定条件を満たす要素のシーケンスを返す()
        {
            var source = Enumerable.Range( 0, 10 );

            var actual = source.TakeWhile( x => x < 3 );

            var expected = new List<int> { 0, 1, 2 };

            Assert.That( actual, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "集計" )]
        public void Aggregateは畳み込み処理を行う()
        {
            var source = Enumerable.Range( 1, 10 );  // => { 1, 2, 3, 4, 5, 6, 7, 8, 9. 10 }

            var actual = source.Aggregate( ( sum, x ) => sum + x );

            Assert.That( actual, Is.EqualTo( 55 ) );
        }

        [Test]
        [Category( "判定" )]
        public void Allは全ての要素が指定条件を満たすか否かを判定する()
        {
            var source = Enumerable.Range( 0, 10 );

            Assert.That( source.All( x => x < 10 ), Is.EqualTo( true ) );
            Assert.That( source.All( x => x < 7 ), Is.EqualTo( false ) );
        }

        [Test]
        [Category( "判定" )]
        public void Allは空シーケンスに対してtrueとなる()
        {
            var source = new List<int>();
            Assert.That( source.All( x => x < 10 ), Is.EqualTo( true ) );
        }

        [Test]
        [Category( "判定" )]
        public void Anyは指定条件を満たす要素が含まれているか否かを判定する()
        {
            var source = Enumerable.Range( 0, 10 );

            Assert.That( source.Any( x => x < 7 ), Is.EqualTo( true ) );
            Assert.That( source.Any( x => x < 0 ), Is.EqualTo( false ) );
        }

        [Test]
        [Category( "判定" )]
        public void Anyは空シーケンスに対してfalseとなる()
        {
            var source = new List<int>();
            Assert.That( source.Any( x => x < 10 ), Is.EqualTo( false ) );
        }

        [Test]
        [Category( "判定" )]
        public void SequenceEqualはシーケンスに対する等価判定する()
        {
            var source = Enumerable.Range( 0, 3 );

            Assert.That( source.SequenceEqual( new List<int> { 0, 1, 2 } ), Is.EqualTo( true ) );
            Assert.That( source.SequenceEqual( new List<int> { 2, 1, 0 } ), Is.EqualTo( false ) );
        }

        [Test]
        [Category( "集合" )]
        public void Unionは指定したシーケンスとの和集合を返す()
        {
            var source = new List<int> { 1, 3, 5 };
            var second = new List<int> { 0, 1, 2, 3 };

            var expected = new List<int> { 0, 1, 2, 3, 5 };

            Assert.That( source.Union( second ), Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "集合" )]
        public void Exceptは指定したシーケンスとの差集合を返す()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5 };
            var second = new List<int> { 0, 1, 2 };

            var expected = new List<int> { 3, 4, 5 };

            Assert.That( source.Except( second ), Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "集合" )]
        public void Intersectは指定したシーケンスとの積集合を返す()
        {
            var source = new List<int> { 0, 1, 2, 3, 4, 5 };
            var second = new List<int> { 4, 5, 6, 7, 8, 9 };

            var expected = new List<int> { 4, 5 };

            Assert.That( source.Intersect( second ), Is.EquivalentTo( expected ) );
        }
    }
}
