#include <iostream>
#include <string>
#include <future>
#include <thread>

#include "sharedmemory.h"

int main()
{
    std::cout << "<<< Quit on press Enter key >>>" << std::endl;

    std::cout << "sizeof(Foo): " << sizeof( Foo ) << std::endl;

    bool exitFlag = false;
    std::future<void> f = std::async( std::launch::async, [&exitFlag]
    {
        auto&& shm = SharedMemory();
        Foo wdata = {};

        int count = 0;
        while ( exitFlag != true )
        {
            wdata.count = count;
            wdata.value = count + 0.777;
            wdata.lucky = ( count % 2 == 0 );
            
            memcpy( wdata.name, "abcdefg", FooNameSize );

            for ( int i = 0; i < FooArraySize; ++i )
            {
                wdata.array[i] = count + i;
            }

            shm.write( wdata );

            unsigned char bytes[sizeof(Foo)] = {};
            memset( bytes, 0x00, sizeof(Foo) );
            memcpy( bytes, &wdata, sizeof(Foo) );

            std::cout << "write: " << count << std::endl;

            std::this_thread::sleep_for( std::chrono::seconds( 1 ) );
            ++count;
        }

        wdata.exitFlag = true;
        shm.write( wdata );
    } );

    std::string buff = "";
    std::getline( std::cin, buff );

    exitFlag = true;

    f.wait();

    return 0;
}
