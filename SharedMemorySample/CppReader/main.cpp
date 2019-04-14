#include <iostream>
#include <thread>

#include "sharedmemory.h"

int main()
{
    auto&& shm = SharedMemory();

    Foo rdata = {};

    while ( true )
    {
        shm.read( rdata );

        std::cout << "count: " << rdata.count << ", "
                  << "ivalue: " << rdata.ivalue << ", "
                  << "dvalue: " << rdata.dvalue << std::endl;

        if ( rdata.exitFlag != 0 )
        {
            break;
        }

        std::this_thread::sleep_for( std::chrono::seconds( 1 ) );
    }

    return 0;
}
