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

        [Test]
        [Category( "ソート" )]
        public void OrderByは昇順にソートしたシーケンスを返す()
        {
            var sorted = Users.OrderBy( x => x.Age );

            sorted.Aggregate( ( pre, x ) =>
            {
                Assert.That( x.Age, Is.GreaterThanOrEqualTo( pre.Age ) );
                return x;
            } );
        }

        [Test]
        [Category( "ソート" )]
        public void OrderByDescendingは降順にソートしたシーケンスを返す()
        {
            var sorted = Users.OrderByDescending( x => x.Age );

            sorted.Aggregate( ( pre, x ) =>
            {
                Assert.That( x.Age, Is.LessThanOrEqualTo( pre.Age ) );
                return x;
            } );
        }

        [Test]
        [Category( "ソート" )]
        public void ThenByにより第2ソートキーを指定できる()
        {
            // Ageで昇順ソート, Ageが等しい場合はIdで昇順ソート
            var sorted = Users
                         .OrderBy( x => x.Age )
                         .ThenBy( x => x.Id );

            sorted.Aggregate( ( pre, x ) =>
            {
                // Ageで昇順ソートされていること
                Assert.That( x.Age, Is.GreaterThanOrEqualTo( pre.Age ) );

                // Ageが等しい場合は、Idで昇順ソートされていること
                if ( x.Age == pre.Age )
                {
                    Assert.That( x.Id, Is.GreaterThan( pre.Id ) );
                }
                return x;
            } );
        }

        [Test]
        [Category( "射影" )]
        public void GroupByは指定したキーでグループ化したシーケンスを返す()
        {
            var list = new List<User>
            {
                new User { Id = 1, Name = "foo", Age = 10 },
                new User { Id = 2, Name = "foo", Age = 11 },
                new User { Id = 3, Name = "foo", Age = 12 },
                new User { Id = 4, Name = "fuga", Age = 13 },
                new User { Id = 5, Name = "fuga", Age = 14 }
            };

            var nameGroup = list.GroupBy( x => x.Name );

            Assert.That( nameGroup.Count(), Is.EqualTo( 2 ) );

            foreach ( var sameName in nameGroup )
            {
                List<User> expected = null;

                if ( sameName.Key == "foo" )
                {
                    expected = new List<User>
                    {
                        new User { Id = 1, Name = "foo", Age = 10 },
                        new User { Id = 2, Name = "foo", Age = 11 },
                        new User { Id = 3, Name = "foo", Age = 12 }
                    };
                }
                else if ( sameName.Key == "fuga" )
                {
                    expected = new List<User>
                    {
                        new User { Id = 4, Name = "fuga", Age = 13 },
                        new User { Id = 5, Name = "fuga", Age = 14 }
                    };
                }
                else
                {
                    Assert.Fail();
                }

                Assert.That( sameName, Is.EquivalentTo( expected ) );
            }

        }

        [Test]
        [Category( "結合" )]
        public void Joinは内部結合したシーケンスを返す()
        {
            // カテゴリテーブルとアイテムテーブルを内部結合し、
            // ( カテゴリ名, アイテム名 )の匿名オブジェクトテーブルを作る
            var innerJoin = CategoryTable.Join( ItemTable,
                c => c.Id,
                i => i.CategoryId,
                ( c, i ) => new { CategoryName = c.Name, ItemName = i.Name } );

            var expected = new List<dynamic>
            {
                new { CategoryName = "category1", ItemName = "item1" },
                new { CategoryName = "category2", ItemName = "item2" },
                new { CategoryName = "category2", ItemName = "item3" },
                new { CategoryName = "category3", ItemName = "item4" },
                new { CategoryName = "category3", ItemName = "item5" },
                new { CategoryName = "category3", ItemName = "item6" }
            };

            Assert.That( innerJoin.Count(), Is.EqualTo( 6 ) );
            Assert.That( innerJoin, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "結合" )]
        public void GroupJoinは左外部結合したシーケンスを返す()
        {
            // カテゴリテーブルにアイテムテーブルを外部結合し、
            // ( カテゴリ名, 1stアイテム名, アイテム数 )の匿名オブジェクトテーブルを作る
            var outerJoin = CategoryTable.GroupJoin( ItemTable,
                c => c.Id,
                i => i.CategoryId,
                ( c, i ) => new
                {
                    CategoryName = c.Name,
                    FirstItemName = i.FirstOrDefault()?.Name ?? string.Empty,
                    ItemCount = i.Count()
                } );

            var expected = new List<dynamic>
            {
                new { CategoryName = "category1", FirstItemName = "item1", ItemCount = 1 },
                new { CategoryName = "category2", FirstItemName = "item2", ItemCount = 2 },
                new { CategoryName = "category3", FirstItemName = "item4", ItemCount = 3 },
                new { CategoryName = "category4", FirstItemName = string.Empty, ItemCount = 0 },
                new { CategoryName = "category5", FirstItemName = string.Empty, ItemCount = 0 }
            };

            Assert.That( outerJoin.Count(), Is.EqualTo( 5 ) );
            Assert.That( outerJoin, Is.EquivalentTo( expected ) );
        }

        [Test]
        [Category( "変換" )]
        public void ToDictionaryは連想配列を返す()
        {
            Dictionary<int, User> id2user = Users.ToDictionary( x => x.Id );

            Assert.That( id2user[1], Is.EqualTo( new User { Id = 1, Name = "Foo1", Age = 10 } ) );
            Assert.That( id2user[10], Is.EqualTo( new User { Id = 10, Name = "Foo", Age = 10 } ) );


            Dictionary<int, string> id2name = Users.ToDictionary( x => x.Id, x => x.Name );

            Assert.That( id2name[1], Is.EqualTo( "Foo1" ) );
            Assert.That( id2name[2], Is.EqualTo( "Foo2" ) );
        }

        [Test]
        [Category( "変換" )]
        public void ToLookupは1対多のディクショナリを返す()
        {
            var nameTable = Users.ToLookup( x => x.Name );

            Assert.That( nameTable["Foo"].Count(), Is.GreaterThanOrEqualTo( 3 ) );
            Assert.That( nameTable["User"], Has.Member( new User { Id = 20, Name = "User", Age = 12 } ) );
        }


        private static IEnumerable<User> Users
        {
            get
            {
                yield return new User { Id = 10, Name = "Foo", Age = 10 };
                yield return new User { Id = 11, Name = "Foo", Age = 11 };
                yield return new User { Id = 12, Name = "Foo", Age = 12 };

                yield return new User { Id = 1, Name = "Foo1", Age = 10 };
                yield return new User { Id = 2, Name = "Foo2", Age = 10 };
                yield return new User { Id = 3, Name = "Foo3", Age = 20 };
                yield return new User { Id = 4, Name = "Foo4", Age = 20 };
                yield return new User { Id = 5, Name = "Foo5", Age = 30 };

                yield return new User { Id = 39, Name = "Foo", Age = 39 };
                yield return new User { Id = 38, Name = "Foo", Age = 38 };
                yield return new User { Id = 37, Name = "Foo", Age = 37 };

                yield return new User { Id = 41, Name = "Foo1", Age = 41 };
                yield return new User { Id = 42, Name = "Foo2", Age = 42 };
                yield return new User { Id = 43, Name = "Foo3", Age = 43 };

                yield return new User { Id = 20, Name = "User", Age = 12 };
                yield return new User { Id = 21, Name = "User", Age = 11 };
                yield return new User { Id = 22, Name = "User", Age = 10 };
            }
        }

        private static IEnumerable<Category> CategoryTable
        {
            get
            {
                return new List<Category>
                {
                    new Category { Id = 1, Name = "category1" },
                    new Category { Id = 2, Name = "category2" },
                    new Category { Id = 3, Name = "category3" },
                    new Category { Id = 4, Name = "category4" },
                    new Category { Id = 5, Name = "category5" },
                };
            }
        }

        private static IEnumerable<Item> ItemTable
        {
            get
            {
                return new List<Item>
                {
                    new Item { Id = 1, Name = "item1", CategoryId = 1 },
                    new Item { Id = 2, Name = "item2", CategoryId = 2 },
                    new Item { Id = 3, Name = "item3", CategoryId = 2 },
                    new Item { Id = 4, Name = "item4", CategoryId = 3 },
                    new Item { Id = 5, Name = "item5", CategoryId = 3 },
                    new Item { Id = 6, Name = "item6", CategoryId = 3 },

                    new Item { Id = 10, Name = "item10", CategoryId = 10 },
                    new Item { Id = 11, Name = "item11", CategoryId = 11 },
                    new Item { Id = 12, Name = "item12", CategoryId = 12 },
                };
            }
        }
    }
}
