#ifndef SHAREDMEMORY_H
#define SHAREDMEMORY_H

#include <Windows.h>
#include "foo.h"

class SharedMemory
{
public:
    SharedMemory();
    virtual ~SharedMemory();

public:
    void open();
    void close();

    void read( Foo& foo ) const;
    void write( const Foo& foo );

private:
    HANDLE m_handle = nullptr;
    void* m_memory = nullptr;
};

#endif // SHAREDMEMORY_H
