#include <iostream>
#include <thread>

#include "sharedmemory.h"

int main()
{
    auto&& shm = SharedMemory();

    Foo rdata = {};

    while ( rdata.exitFlag == false )
    {
        shm.read( rdata );

        std::cout << "count: " << rdata.count << ", "
                  << "value: " << rdata.value << ", "
                  << "lucky: " << rdata.lucky << ", "
                  << "name: " << rdata.name << ", "
                  << "array[7]: " << rdata.array[7] << std::endl;

        std::this_thread::sleep_for( std::chrono::seconds( 1 ) );
    }

    return 0;
}
