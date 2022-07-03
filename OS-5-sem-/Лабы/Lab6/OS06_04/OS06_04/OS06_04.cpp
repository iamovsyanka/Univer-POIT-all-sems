#include <iostream>
#include <Windows.h>

using namespace std;

void sh(HANDLE pheap);

int main() {
    HANDLE pheap = GetProcessHeap();

    cout << "---------------Before---------------";
    sh(pheap);

    {
        int size = 300000;
        int* m = new int[size];
        cout << "-- m = " << hex << m << ", size = " << dec << size << " \n\n";
    }

    cout << "\n\n------------After--------------";
    sh(pheap);
}

void sh(HANDLE pheap) {
    PROCESS_HEAP_ENTRY phe;
    phe.lpData = NULL;
    while (HeapWalk(pheap, &phe)) {
        cout << "-- address = " << hex << phe.lpData
            << ", size = " << dec << phe.cbData
            << ((phe.wFlags & PROCESS_HEAP_REGION) ? " R" : "") // начало непрерывной области
            << ((phe.wFlags & PROCESS_HEAP_UNCOMMITTED_RANGE) ? " U" : "") // нераспределенная область
            << ((phe.wFlags & PROCESS_HEAP_ENTRY_BUSY) ? " B" : "") // распределенная область
            << "\n";
    }
    cout << "-----------------------------------\n\n";
}