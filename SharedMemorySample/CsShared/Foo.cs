using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace CsShared
{
    /*
    C++のFoo構造体に相当するC#クラス

    struct Foo
    {
        int count;
        double value;
        bool lucky;
        char name[8];
        int array[8];
        bool exitFlag;
    };
    */
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 8 )]
    public class Foo
    {
        public Int32 _count;

        public Double _value;

        // 注: 
        // UnmanagedType.Boolは、WIN32 BOOL型(4byte)に対応する
        // c++ bool型は1byteなので、UnmanagedType.U1が対応
        [MarshalAs( UnmanagedType.U1 )]
        public bool _lucky;

        [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 8 )]
        public string _name;

        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 8 )]
        public Int32[] _array = new Int32[8];

        [MarshalAs( UnmanagedType.U1 )]
        public bool _exitFlag;
    }
}
