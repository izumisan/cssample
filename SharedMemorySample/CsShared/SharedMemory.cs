using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO.MemoryMappedFiles;

namespace CsShared
{
    public class SharedMemory
    {
        public SharedMemory()
        {
            open();
        }

        ~SharedMemory()
        {
            close();
        }

        public void open()
        {
            _mmf = MemoryMappedFile.CreateOrOpen( "sharedmemorysample", Marshal.SizeOf<Foo>() );
            _accessor = _mmf.CreateViewAccessor();
        }

        public void close()
        {
            _accessor.Dispose();
            _mmf.Dispose();
        }

        public void read( ref Foo foo )
        {
            int size = Marshal.SizeOf<Foo>();
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocCoTaskMem( size );

            _accessor.ReadArray( 0, bytes, 0, size );
            Marshal.Copy( bytes, 0, ptr, size );
            Marshal.PtrToStructure( ptr, foo );
            Marshal.FreeCoTaskMem( ptr );
        }

        public void write( Foo foo )
        {
            int size = Marshal.SizeOf<Foo>();
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocCoTaskMem( size );

            Marshal.StructureToPtr( foo, ptr, false );
            Marshal.Copy( ptr, bytes, 0, size );
            Marshal.FreeCoTaskMem( ptr );

            _accessor.WriteArray( 0, bytes, 0, size );
        }

        private MemoryMappedFile _mmf;
        private MemoryMappedViewAccessor _accessor;
    }
}
