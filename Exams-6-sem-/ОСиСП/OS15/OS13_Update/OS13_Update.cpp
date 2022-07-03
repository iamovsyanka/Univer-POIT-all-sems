#include <iostream>
#include "HTAPI.h"
#include "HT.h"
#include <string>

using namespace std;

string key = "my_key";
string value = "my_value";
HT::HTHANDLE* ht = NULL;

void Do(LPCSTR FileName) {
	//path of mapping file
	char cwd[MAX_PATH];
	GetModuleFileNameA(NULL, cwd, MAX_PATH);
	string path(cwd);
	int pos = path.find_last_of("\\") + 1;
	string filePath = path.substr(0, pos) + FileName;
	char* filePathCost = (char*)filePath.c_str();
	DWORD er;

	HT::HTHANDLE* ht = HTAPI::Open(filePathCost);
	if (ht != NULL) {
		printf("\nHT-Storage Created filename=%s, snapshotinterval=%d, capacity = %d, maxkeylength = %d, maxdatalength = %d",
			filePathCost, ht->SecSnapshotInterval, ht->Capacity, ht->MaxKeyLength, ht->MaxPayloadLength);
	}
	else {
		printf("\n some error fail@: %d", GetLastError());
		return;
	}
	srand(time(NULL));
	HT::Element* element;
	int random;
	int value = 0;
	while (true) {
		random = rand() % 50;
		element = new HT::Element((void*)&random, 4, &value, 4);
		element = HTAPI::Get(ht, element);
		if (element != NULL) {
			printf("\nSuccessful getting element with key: %d. Value: %d", *(int*)element->key, *(int*)element->payload);
			value = *(int*)element->payload + 1;
			if (HTAPI::Update(ht, element, &value, 4)) {
				printf("\nSuccessful updating element with key: %d. OldValue: %d", *(int*)element->key, *(int*)element->payload);
			}
			else {
				printf("\nFail with updating key: %d. Message: %s", random, HTAPI::GetLastHtError(ht));
			}
		}
		else {
			printf("\nFail with getting key: %d. Message: %s", random, HTAPI::GetLastHtError(ht));
		}
		Sleep(1000);
	}


	HTAPI::Close(ht);
}

int main(int argc, char* argv[])
{

	if (HTAPI::OpenApi()) {

		if (argc == 2) {
		}
		else {
			printf("\nProgram need 1 parameter! argc: %d.\nDefault parameters are used", argc);
			argv[1] = (char*)"HT.txt";
		}
		Do(argv[1]);


		if (HTAPI::CloseApi() == false)
			printf("error with close api\n");
	}
	else {
		printf("error with open api\n");
	}
	return 0;
}