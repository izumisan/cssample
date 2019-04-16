using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace CsShared
{
    [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4 )]
    public class Foo
    {
        public Int32 _count;
        public Int32 _ivalue;
        public Double _dvalue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512 )]
        public Int32[] _array = new Int32[512];
        public Int32 _exitFlag;
    }
}
