using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Diagnostics;

namespace MSTestSample
{
    [TestClass]
    public class MSTest
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MSTest()
        {
            Trace.WriteLine( "コンストラクタ" );
        }

        public TestContext TestContext { get; set; }

        #region 事前処理・事後処理

        [ClassInitialize()]
        public static void ClassInitialize( TestContext testContext )
        {
            Trace.WriteLine( "ClassInitialize" );
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            Trace.WriteLine( "ClassCleanup" );
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            Trace.WriteLine( "TestInitialize" );
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            Trace.WriteLine( "TestCleanup" );
        }
        #endregion

        #region テスト対象
        private Func<double, double, double> SumCalculator { get; set; } = ( a, b ) => { return a + b; };
        private Action<int> HeavyProcessing { get; set; } = ( msec ) => { System.Threading.Thread.Sleep( msec ); };
        private Action ThrowException = () => { throw new Exception( "exception" ); };
        #endregion

        [TestMethod]
        [TestCategory( "S" )]
        [Description( "Assertを利用したテストメソッド" )]
        public void SumCalculatorのテスト()
        {
            Trace.WriteLine( nameof( SumCalculatorのテスト ) );

            double x = 1.0;
            double y = 2.0;
            double expected = 3.0;

            double actual = SumCalculator( x, y );
            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [TestCategory( "S" )]
        [Description( "CollectionAssertを利用したテストメソッド" )]
        public void SumCalculatorのテスト2()
        {
            Trace.WriteLine( nameof( SumCalculatorのテスト2 ) );

            var expected = new List<double>();
            var actual = new List<double>();

            foreach ( double x in Enumerable.Range( 0, 10 ) )
            {
                expected.Add( x + x );

                actual.Add( SumCalculator( x, x ) );
            }

            CollectionAssert.AreEqual( expected, actual );
        }

        [TestMethod]
        [TestCategory( "S" )]
        [Description( "外部ファイルによるパラメトリックテスト" )]
        [DataSource( "Microsoft.VisualStudio.TestTools.DataSource.CSV", @"|DataDirectory|\testdata\SumCalculatorTestData.csv", "SumCalculatorTestData#csv", DataAccessMethod.Sequential )]
        public void SumCalculatorのパラメトリックテスト()
        {
            //@@@ DataSourceを利用するには、参照先に「System.Data」を追加する必要がある

            Trace.WriteLine( nameof( SumCalculatorのパラメトリックテスト ) );

            double a = double.Parse( TestContext.DataRow["arg1"].ToString() );
            double b = double.Parse( TestContext.DataRow["arg2"].ToString() );
            double expected = double.Parse( TestContext.DataRow["expected"].ToString() );

            double actual = SumCalculator( a, b );

            Assert.AreEqual( expected, actual );
        }

        [TestMethod]
        [TestCategory( "S" )]
        [TestCategory( "Exception" )]
        [Description( "指定した例外発生でOKとなるテストメソッド" )]
        [ExpectedException( typeof( Exception ) )]
        public void ThrowExceptionは例外を発生する()
        {
            Trace.WriteLine( nameof( ThrowExceptionは例外を発生する ) );

            ThrowException();
        }

        [TestMethod]
        [Timeout( 100 )]
        public void タイムアウトテスト()
        {
            Trace.WriteLine( nameof( タイムアウトテスト ) );

            HeavyProcessing( 10 );
        }

        [TestMethod]
        [Timeout( 100 )]
        [Description( "タイムアウトでNGとなるテストメソッド" )]
        public void タイムアウトテスト2_NGケース()
        {
            Trace.WriteLine( nameof( タイムアウトテスト2_NGケース ) );

            HeavyProcessing( 50 );
            HeavyProcessing( 50 );
            HeavyProcessing( 50 );
        }

        [TestMethod]
        [Timeout( 200 )]
        public void タイムアウトテスト2_OKケース()
        {
            Trace.WriteLine( nameof( タイムアウトテスト2_OKケース ) );

            HeavyProcessing( 50 );
            HeavyProcessing( 50 );
            HeavyProcessing( 50 );
        }
    }
}
