using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestSample
{
    [TestClass]
    public class MSTestV2
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MSTestV2()
        {
        }

        #region テストコンテキスト

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion

        #region 事前・事後処理

        [ClassInitialize()]
        public static void ClassInitialize( TestContext testContext ) { }

        [ClassCleanup()]
        public static void ClassCleanup() { }

        [TestInitialize()]
        public void TestInitialize() { }

        [TestCleanup()]
        public void TestCleanup() { }

        #endregion

        #region テスト対象
        private Func<double, double, double> SumCalculator { get; set; } = ( a, b ) => { return a + b; };
        #endregion

        [DataTestMethod]
        [TestCategory( "MSTest V2" )]
        [Description( "パラメトリックテスト" )]
        [DataRow( 1, 1, 2 )]
        [DataRow( 1, 2, 3 )]
        [DataRow( -1, -10, -11 )]
        public void パラメトリックテスト( double a, double b, double expected )
        {
            double actual = SumCalculator( a, b );

            Assert.AreEqual( expected, actual );
        }

        [DataTestMethod]
        [TestCategory( "MSTest V2" )]
        [Description( "データメソッドを用いたパラメトリックテスト" )]
        [DynamicData( nameof( パラメトリックテスト2_data ), DynamicDataSourceType.Method )]
        public void パラメトリックテスト2( double a, double b, double expected )
        {
            double actual = SumCalculator( a, b );

            Assert.AreEqual( expected, actual );
        }

        public static IEnumerable<object[]> パラメトリックテスト2_data()
        {
            yield return new object[] { 1, 1, 2 };
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { -1, -10, -11 };
        }

        [DataTestMethod]
        [TestCategory( "MSTest V2" )]
        [Description( "データプロパティを用いたパラメトリックテスト" )]
        [DynamicData( nameof( パラメトリックテスト3_data ), DynamicDataSourceType.Property )]
        public void パラメトリックテスト3( double a, double b, double expected )
        {
            double actual = SumCalculator( a, b );

            Assert.AreEqual( expected, actual );
        }

        public static IEnumerable<object[]> パラメトリックテスト3_data
        {
            get
            {
                yield return new object[] { 1, 1, 2 };
                yield return new object[] { 1, 2, 3 };
                yield return new object[] { -1, -10, -11 };
            }
        }
    }
}
