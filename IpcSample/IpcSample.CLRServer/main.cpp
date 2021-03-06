#include "stdafx.h"

using namespace System;
using namespace IpcSample::Shared;

int main(array<System::String ^> ^args)
{
    IpcServer^ ipcserver = gcnew IpcServer();

    ipcserver->open();

    Console::WriteLine( "CLRServer running ..." );

    Console::WriteLine( "Read IPC data on press enter." );
    Console::ReadLine();

    Console::WriteLine( ipcserver->ipcData->Value );

    Console::WriteLine( "Exit on press enter." );
    Console::ReadLine();

    return 0;
}
