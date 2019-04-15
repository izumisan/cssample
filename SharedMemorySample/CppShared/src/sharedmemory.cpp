#include <cassert>
#include "sharedmemory.h"

constexpr size_t memorySize_ = sizeof( Foo );

SharedMemory::SharedMemory()
{
    open();
}

SharedMemory::~SharedMemory()
{
    close();
}

void SharedMemory::open()
{
    m_handle = ::CreateFileMapping( INVALID_HANDLE_VALUE,
                                    0,
                                    PAGE_READWRITE,
                                    0,
                                    memorySize_,
                                    "sharedmemorysample" );

    if ( m_handle != nullptr )
    {
        m_memory = ::MapViewOfFile( m_handle,
                                    FILE_MAP_ALL_ACCESS,
                                    0,
                                    0,
                                    memorySize_ );

        if ( m_memory == 0 )
        {
            assert( !"Fail to MapViewOfFile" );
        }
    }
    else
    {
        assert( !"Fail to CreateFileMapping" );
    }
}

void SharedMemory::close()
{
    ::UnmapViewOfFile( m_memory );
    ::CloseHandle( m_handle );
}

void SharedMemory::read( Foo& foo ) const
{
    ::memcpy( &foo, m_memory, memorySize_ );
}

void SharedMemory::write( const Foo& foo )
{
    ::memcpy( m_memory, &foo, memorySize_ );
}
