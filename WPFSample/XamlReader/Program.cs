using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlReader
{
    class Program
    {
        static void Main( string[] args )
        {
            // アセンブリからXAMLのストリームを取得
            var xaml = typeof( Person ).Assembly.GetManifestResourceStream( "XamlReader.Person.xaml" );

            // XAMLからPersonオブジェクトを取得
            var p = System.Windows.Markup.XamlReader.Load( xaml ) as Person;

            Console.WriteLine( $"Birthday: { p.Birthday }" );
        }
    }
}
