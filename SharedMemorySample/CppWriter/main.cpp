#include <iostream>
#include <thread>

#include "sharedmemory.h"

int main()
{
    auto&& shm = SharedMemory();

    Foo wdata = {};

    int count = 0;
    while ( count < 10 )
    {
        wdata.count = count;
        wdata.ivalue = count + 1;
        wdata.dvalue = count + 0.777;
        for ( int i = 0; i < 512; ++i )
        {
            wdata.array[i] = count + i;
        }

        shm.write( wdata );

        std::cout << "write: " << count << std::endl;

        std::this_thread::sleep_for( std::chrono::seconds( 1 ) );
        ++count;
    }

    wdata.exitFlag = 1;
    shm.write( wdata );

    return 0;
}
