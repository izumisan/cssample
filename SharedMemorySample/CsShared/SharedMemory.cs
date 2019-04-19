using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO.MemoryMappedFiles;

namespace CsShared
{
    public class SharedMemory : IDisposable
    {
        public SharedMemory()
        {
            open();
        }

        ~SharedMemory()
        {
            Dispose( false );
        }

        #region Disposeパターン

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( !_disposed )
            {
                if ( disposing )
                {
                    close();
                }
                _disposed = true;
            }
        }
        #endregion

        private MemoryMappedFile _mmf = null;
        private MemoryMappedViewAccessor _accessor = null;
        private Stopwatch _stopwatch = new Stopwatch();
        private Queue<long> _accessTimeQueue = new Queue<long>();

        public double AverageTime
        {
            get { return _accessTimeQueue.Average(); }
        }

        public long MaxTime
        {
            get { return _accessTimeQueue.Max(); }
        }

        public long MinTime
        {
            get { return _accessTimeQueue.Min(); }
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
            _stopwatch.Start();

            int size = Marshal.SizeOf<Foo>();
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocCoTaskMem( size );

            // 共有メモリ（メモリマップトファイル）からデータを読み出す
            _accessor.ReadArray<byte>( 0, bytes, 0, size );
            // バイト列データをIntPtr(アンマネージポインタ)にコピー
            Marshal.Copy( bytes, 0, ptr, size );
            // アンマネージデータをマネージデータにマーシャリング
            foo = Marshal.PtrToStructure<Foo>( ptr );

            Marshal.FreeCoTaskMem( ptr );

            _stopwatch.Stop();
            
            if ( 100 < _accessTimeQueue.Count )
            {
                _accessTimeQueue.Dequeue();
            }
            _accessTimeQueue.Enqueue( _stopwatch.ElapsedMilliseconds );

            _stopwatch.Reset();
        }

        public void write( Foo foo )
        {
            _stopwatch.Start();

            int size = Marshal.SizeOf<Foo>();
            byte[] bytes = new byte[size];
            IntPtr ptr = Marshal.AllocCoTaskMem( size );

            // マネージデータをアンマネージデータにマーシャリング
            Marshal.StructureToPtr<Foo>( foo, ptr, false );
            // IntPtr(アンマネージポインタ)をバイト列データにコピー
            Marshal.Copy( ptr, bytes, 0, size );
            // バイト列データを共有メモリ（メモリマップトファイル）に書き出す
            _accessor.WriteArray<byte>( 0, bytes, 0, size );

            _accessor.Flush();

            Marshal.FreeCoTaskMem( ptr );

            _stopwatch.Stop();

            if ( 100 < _accessTimeQueue.Count )
            {
                _accessTimeQueue.Dequeue();
            }
            _accessTimeQueue.Enqueue( _stopwatch.ElapsedMilliseconds );

            _stopwatch.Reset();
        }
    }
}
