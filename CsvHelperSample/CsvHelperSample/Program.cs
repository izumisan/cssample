using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using CsvHelper;

namespace CsvHelperSample
{
    class Program
    {
        static void Main( string[] args )
        {
            // csvの読み込み
            //------------------------------------------------------------------

            var file = "sampledata.csv";
            using ( var csv = new CsvReader( new StreamReader( file ) ) )
            {
                csv.Configuration.HasHeaderRecord = true;  // ヘッダ行あり
                csv.Configuration.AllowComments = true;  // コメント行('#')あり
                csv.Configuration.IgnoreBlankLines = true;  // ブランク行を無視

                csv.Configuration.RegisterClassMap<SampleDataMap>();

                var records = csv.GetRecords<SampleData>().ToList();
            }


            // csvの出力
            //------------------------------------------------------------------

            var wdata = new List<SampleData>
            {
                new SampleData
                {
                    Str = "foo",
                    Int = 168,
                    Double = 123.456,
                    Month = MonthEnum.Jan,
                    Month1 = MonthEnum.Mar,
                    Month2 = MonthEnum.May,
                    Month3 = MonthEnum.Jul,
                    Foo = new FooData
                    {
                        data1 = 111,
                        data2 = 333
                    }
                },
                new SampleData
                {
                    Str = "bar",
                    Int = 2,
                    Double = 24.68,
                    Month = MonthEnum.Feb,
                    Month1 = MonthEnum.Apr,
                    Month2 = MonthEnum.Jun,
                    Month3 = MonthEnum.Aug,
                    Foo = new FooData
                    {
                        data1 = 222,
                        data2 = 444
                    }
                }
            };

            var outfile = "outdata.csv";
            using ( var csv = new CsvWriter( new StreamWriter( outfile ) ) )
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<SampleDataMap>();

                csv.WriteRecords<SampleData>( wdata );
            }
        }
    }
}
