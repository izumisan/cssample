using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace CsShared
{
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 8 )]
    public class Foo
    {
        public Int32 _count;
        public Double _value;
        [MarshalAs(UnmanagedType.U1)]
        bool _lucky;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512 )]
        public Int32[] _array = new Int32[512];
        [MarshalAs( UnmanagedType.U1 )]
        public bool _exitFlag;
    }
}
