 
#include <iostream>
#include "vector"
#include <Windows.h>
#include <string>

using namespace std;

// Main
int main()
{
    int i = 0;
    DCB dcb;
    HANDLE hCom;
    BOOL fSuccess;

    hCom = CreateFile(L"COM4",
        GENERIC_READ | GENERIC_WRITE,
        0,      //  must be opened with exclusive-access
        NULL,   //  default security attributes
        OPEN_EXISTING, //  must use OPEN_EXISTING
        0,      //  not overlapped I/O
        NULL); //  hTemplate must be NULL for comm devices

    if (hCom == INVALID_HANDLE_VALUE)
    {
        //  Handle the error.
        printf("CreateFile failed with error %d.\n", GetLastError());
        return (1);
    }

   
    dcb.DCBlength = sizeof(DCB);

    
    fSuccess = GetCommState(hCom, &dcb);

    if (!fSuccess)
    {
       
        printf("GetCommState failed with error %d.\n", GetLastError());
        
    }

 
    cin >> i;

}
 