using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace AssertThat
{
    [TestFixture]
    public class CalculatorTest
    {
        public CalculatorTest()
        {
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Isクラス()
        {
            double a = 10.0;
            double b = -5.0;

            double actual = Calculator.sum( a, b );

            Assert.That( actual, Is.EqualTo( 5.0 ) );

            Assert.That( actual, Is.GreaterThan( 4.9 ) );
            Assert.That( actual, Is.InRange( 0.0, 10.0 ) );

            Assert.That( 1.0, Is.Positive );
            Assert.That( -1.0, Is.Negative );
            Assert.That( 0.0, Is.Zero );

            Assert.That( true, Is.True );
            Assert.That( false, Is.False );
        }

        [Test]
        public void Hasクラス()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            // メンバー"1"を持っている
            Assert.That( list, Has.Member( 1 ) );

            // "2"をいくつか持っている
            Assert.That( list, Has.Some.EqualTo( 2 ) );

            // Countは"6"である
            Assert.That( list, Has.Count.EqualTo( 6 ) );

            // "1"より小さいのは1つである
            Assert.That( list, Has.One.LessThan( 1 ) );

            // 全て"100"より小さい
            Assert.That( list, Has.All.LessThan( 100 ) );

            // メンバー"10"は持っていない
            Assert.That( list, Has.No.Member( 10 ) );

            // "100"より大きいものはない
            Assert.That( list, Has.None.GreaterThan( 100 ) );
            
            // 全てemptyである
            Assert.That( new List<int>(), Has.All.Empty );
        }

        [Test]
        public void Collectionのテスト()
        {
            var list = new List<int> { 1, 2, 2, 3, 3, 3 };

            // 条件を満たす"メンバー数"に関するアサーション

            // "2"に等しいメンバーは2つである
            Assert.That( list, Has.Exactly( 2 ).EqualTo( 2 ) );

            // "3"より小さいメンバーは3つである
            Assert.That( list, Has.Exactly( 3 ).LessThan( 3 ) );


            // 集合に関するアサーション

            var expected1 = new List<int> { 0, 1, 2, 2, 3, 3, 3, 4, 5, 6 };
            // listはexpected1のサブセット(部分集合)である
            // ( list ⊆ expected1 )
            Assert.That( list, Is.SubsetOf( expected1 ) );

            var expected2 = new List<int> { 1, 2, 3 };
            // listはexpected2のスーパーセットである
            // ( list ⊇ expected2 )
            Assert.That( list, Is.SupersetOf( expected2 ) );
        }

        [Test]
        public void Doesクラス()
        {
            Assert.That( "abcde", Does.Contain( "bc" ) );
            Assert.That( "abcde", Does.StartWith( "ab" ) );

            Assert.That( "abcde", Does.Match( "a*e" ) );
        }

        [Test]
        public void Throwsクラス()
        {
            Assert.That( () => Calculator.div( 1.0, 0.0 ), Throws.Exception );
            Assert.That( () => Calculator.div( 1.0, 0.0 ), Throws.TypeOf<DivideByZeroException>() );
            Assert.That( () => Calculator.div( 1.0, 0.0 ), Throws.Exception.Message.EqualTo( "error" ) );

            Assert.That( () => Calculator.div( 10.0, 2.0 ), Throws.Nothing );
        }

        [Test]
        public void 複合条件()
        {
            // 0.0以上かつ100.0以下
            Assert.That( Calculator.sum( 5.0, 5.0 ), Is.GreaterThan( 0.0 ).And.LessThan( 100.0 ) );

            var list = new List<int> { 1, 2, 3, 4, 5 };

            // 0 又は 5 を含んでいる
            Assert.That( list, Has.Some.EqualTo( 0 ).Or.Some.EqualTo( 5 ) );

            // 1 又は 10 を含んでいる
            Assert.That( list, Has.Some.EqualTo( 1 ).Or.Some.EqualTo( 10 ) );

            // 0を含んでいない かつ 3を含んでいる
            Assert.That( list, Has.None.EqualTo( 0 ).And.EqualTo( 3 ) );
        }
    }
}
