#include <iostream>
#include <string>
#include <future>
#include <thread>

#include "sharedmemory.h"

int main()
{
    std::cout << "<<< Quit on press Enter key >>>" << std::endl;

    bool exitFlag = false;
    std::future<void> f = std::async( std::launch::async, [&exitFlag]
    {
        auto&& shm = SharedMemory();
        Foo wdata = {};

        int count = 0;
        while ( exitFlag != true )
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
    } );

    std::string buff = "";
    std::getline( std::cin, buff );

    exitFlag = true;

    f.wait();

    return 0;
}
