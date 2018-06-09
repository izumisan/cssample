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
            var file = "../../sampledata.csv";
            using ( var csv = new CsvReader( new StreamReader( file ) ) )
            {
                csv.Configuration.HasHeaderRecord = true;  // ヘッダ行あり
                csv.Configuration.AllowComments = true;  // コメント行('#')あり
                csv.Configuration.IgnoreBlankLines = true;  // ブランク行を無視

                csv.Configuration.RegisterClassMap<SampleDataMap>();

                var records = csv.GetRecords<SampleData>().ToList();
            }
        }
    }
}
