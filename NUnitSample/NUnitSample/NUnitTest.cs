﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using NUnit.Framework;

namespace NUnitSample
{
    [TestFixture]
    public class NUnitTest
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NUnitTest()
        {
            Trace.WriteLine( "コンストラクタ" );
        }

        [SetUp]
        public void SetUp()
        {
            Trace.WriteLine( "SetUp" );
        }

        [TearDown]
        public void TearDown()
        {
            Trace.WriteLine( "TearDown" );
        }

        #region テストターゲット
        private Func<double, double, double> SumCalculator { get; set; } = ( a, b ) => { return a + b; };
        #endregion

        //----------------------------------------------------------------------
        /// <summary>
        /// テストメソッド (旧アサーション)
        /// </summary>
        [Test]
        public void 普通のテストメソッド_旧Assertモデル()
        {
            Trace.WriteLine( nameof( 普通のテストメソッド_旧Assertモデル ) );

            double a = 1.0;
            double b = 6.0;

            double actual = SumCalculator( a, b );

            Assert.AreEqual( 7.0, actual );
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// テストメソッド (新アサーション)
        /// </summary>
        [Test]
        public void 普通のテストメソッド_新Assertモデル()
        {
            Trace.WriteLine( nameof( 普通のテストメソッド_新Assertモデル ) );

            double a = 1.0;
            double b = 6.0;

            double actual = SumCalculator( a, b );

            Assert.That( actual, Is.EqualTo( 7.0 ) );
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// パラメトリックテスト
        /// </summary>
        [TestCase( 1.0, 6.0, 7.0 )]
        [TestCase( 2.0, 3.0, 5.0 )]
        [TestCase( 3.0, 4.0, 7.0 )]
        public void パラメトリックテスト( double a, double b, double expected )
        {
            Trace.Write( nameof( パラメトリックテスト ) );

            double actual = SumCalculator( a, b );

            Assert.That( actual, Is.EqualTo( expected ) );
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// パラメトリックテスト
        /// 
        /// テストメソッドの戻り値が期待結果
        /// </summary>
        [TestCase( 1.0, 2.0, ExpectedResult = 3.0 )]
        [TestCase( 2.0, 4.0, ExpectedResult = 6.0 )]
        public double パラメトリックテスト2( double a, double b )
        {
            Trace.WriteLine( nameof( パラメトリックテスト2 ) );

            return SumCalculator( a, b );
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// パラメトリックテスト
        /// 
        /// テストデータを返すプロパティを使用
        /// </summary>
        [TestCaseSource( nameof( テストデータプロパティ ) )]
        public void パラメトリックテスト3( double a, double b, double expected )
        {
            Trace.WriteLine( nameof( パラメトリックテスト3 ) );

            double actual = SumCalculator( a, b );

            Assert.That( actual, Is.EqualTo( expected ) );
        }

        private static IEnumerable<object[]> テストデータプロパティ
        {
            get
            {
                yield return new object[] { 1.0, 3.0, 4.0 };
                yield return new object[] { 2.0, 6.0, 8.0 };
                yield return new object[] { 2.0, -6.0, -4.0 };
            }
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// パラメトリックテスト
        /// 
        /// テストデータを返すメソッドを使用
        /// </summary>
        [TestCaseSource( nameof( テストデータメソッド ) )]
        public void パラメトリックテスト4( double a, double b, double expected )
        {
            Trace.WriteLine( nameof( パラメトリックテスト4 ) );

            double actual = SumCalculator( a, b );

            Assert.That( actual, Is.EqualTo( expected ) );
        }

        private static IEnumerable<object[]> テストデータメソッド()
        {
            yield return new object[] { 1.0, 3.0, 4.0 };
            yield return new object[] { 2.0, 6.0, 8.0 };
            yield return new object[] { 2.0, -6.0, -4.0 };
        }
    }
}
