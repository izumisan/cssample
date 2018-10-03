using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NUnit.Framework;

namespace ParametricTest
{
    [TestFixture]
    public class ParametricTest
    {
        /// <summary>
        /// RandomAttributeで[-100,100]のランダムなテストデータを自動生成する
        /// </summary>
        [Test]
        public void Random属性サンプル( [Random( -100.0, 100.0, 1000 )] double input )
        {
            Debug.Print( $"Random: { input }" );

            Assert.That( true );
        }

        /// <summary>
        /// RangeAttributeで[-10,10]の0.1間隔のテストデータを自動生成する
        /// </summary>
        [Test]
        public void Range属性サンプル( [Range( -10.0, 10.0, 0.1 )] double input )
        {
            Debug.Print( $"Range: { input }" );

            Assert.That( true );
        }

        /// <summary>
        /// ValuesAttribute
        /// </summary>
        [Test]
        public void Values属性サンプル( [Values] DayOfWeek input )
        {
            Debug.Print( $"Values: { input }" );

            Assert.That( true );
        }

        /// <summary>
        /// 組み合わせテスト
        /// 
        /// デフォルト(Combinatiorial属性)では、
        /// 全ての組み合わせのテストデータを自動生成する
        /// （5 x 5 x 3 = 75パターン）
        /// </summary>
        [Test]
        public void Combinatiorial属性サンプル( [Values( 0, 2, 4, 6, 8 )] int x, 
                                                [Values( 1, 3, 5, 7, 9 )] int y,
                                                [Values( 'a', 'b', 'c' )] char c )
        {
            Debug.Print( $"Values: x={ x }, y={ y }, c={ c }" );

            Assert.That( true );
        }

        /// <summary>
        /// 組み合わせテスト
        /// 
        /// PairwiseAttributeでオールペア法によるテストデータを自動生成する
        /// </summary>
        [Test]
        [Pairwise]
        public void Pairwise属性サンプル( [Values( 0, 2, 4, 6, 8 )] int x,
                                        　[Values( 1, 3, 5, 7, 9 )] int y,
                                          [Values( 'a', 'b', 'c' )] char c )
        {
            Debug.Print( $"Pairwise: x={ x }, y={ y }, c={ c }" );

            Assert.That( true );
        }

        /// <summary>
        /// 組み合わせテスト
        /// 
        /// SequentialAttributeで順組みによるテストデータを自動生成する
        /// </summary>
        [Test]
        [Sequential]
        public void Sequential属性サンプル( [Values( 0, 2, 4, 6, 8 )] int x,
                                            [Values( 1, 3, 5, 7, 9 )] int y,
                                            [Values( 'a', 'b', 'c' )] char c )
        {
            Debug.Print( $"Pairwise: x={ x }, y={ y }, c={ c }" );

            Assert.That( true );
        }
    }
}
