using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Diagnostics;

namespace AttributeSample
{
    public static class Program
    {
        static void Main()
        {
            // Class1クラスに付与されているの属性を取得する
            Attribute[] attributes = Attribute.GetCustomAttributes( typeof( Class1 ) );

            attributes.ToList().ForEach( attr =>
            {
                Debug.WriteLine( attr.GetType().Name );

                if ( attr is FooAttribute )
                {
                    var fooattr = attr as FooAttribute;
                    Debug.Print( $"[Foo] Name: { fooattr.Name }" );
                }
                else if ( attr is BarAttribute )
                {
                    var barattr = attr as BarAttribute;
                    Debug.Print( $"[Bar] Name: { barattr.Name }, Message: { barattr.Message }, Value: { barattr.Value }, Lucky: { barattr.Lucky }" );
                }
                else
                {
                }
            } );
        }
    }
}
