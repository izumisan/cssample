using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Forms;
using System.IO;
using NLog;

namespace ArchiveLog
{
    class Program
    {
        static void Main( string[] args )
        {
            var result = MessageBox.Show( 
                "NLogによる古いログファイル削除の確認のため、ダミーのログファイルを作成しますか？", 
                "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question );

            if ( result == DialogResult.Yes )
            {
                CreateDummyFiles();

                MessageBox.Show(
                    "ダミーファイルを作成しました。" + Environment.NewLine
                    + "再実行により、古いログファイルはNLogにより削除されます" + Environment.NewLine
                    + "(次回実行時は、「いいえ」を選択してください)",
                    "通知", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            {
                ILogger logger = LogManager.GetCurrentClassLogger();
                logger.Info( "========== START ==========" );
                logger.Trace( "foo" );
                logger.Debug( "bar" );
                logger.Info( "baz" );
                logger.Warn( "qux" );
                logger.Error( "quux" );
                logger.Info( "==========  END  ==========" );
            }
        }

        static void CreateDummyFiles()
        {
            var today = DateTime.Today;
            for ( int i = 0; i < 10; ++i )
            {
                var backdate = today.Subtract( TimeSpan.FromDays( i + 1 ) );
                var path = Path.Combine( "logs", $"{ backdate.ToString( "yyyy-MM-dd" ) }.log" );
                File.Create( path );
            }
        }
    }
}
