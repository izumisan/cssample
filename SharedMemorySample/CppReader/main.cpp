#include <iostream>
#include <thread>

#include "sharedmemory.h"

int main()
{
    auto&& shm = SharedMemory();

    Foo rdata = {};

    while ( rdata.exitFlag == 0 )
    {
        shm.read( rdata );

        std::cout << "count: " << rdata.count << ", "
                  << "ivalue: " << rdata.ivalue << ", "
                  << "dvalue: " << rdata.dvalue << std::endl;

        std::this_thread::sleep_for( std::chrono::seconds( 1 ) );
    }

    return 0;
}
