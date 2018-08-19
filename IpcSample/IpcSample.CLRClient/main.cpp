#include <iostream>
#include <string>

using namespace IpcSample::Shared;

int main()
{
    IpcClient^ client = gcnew IpcClient();
    client->open();

    std::cout << "CLRClient running..." << std::endl;

    std::string input;

    while ( true )
    {
        std::cout << "[Enter] read/write, [Any Key] quit" << std::endl;

        input.clear();
        std::getline( std::cin, input );

        if ( input.size() != 0 )
        {
            break;
        }

        auto&& rdata = client->ipcData->Value;
        auto&& wdata = rdata + 10;
        client->ipcData->Value = wdata;

        std::cout << rdata << " >>> +10 >>> " << wdata << std::endl;
        std::cout << std::endl;
    }

    return 0;
}
