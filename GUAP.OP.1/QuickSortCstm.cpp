#include "QuickSortCstm.h"
#include "MyConsole.h"
#include <string>
#include <istream>

using namespace std;
namespace QuickSortCommand {
	void LaunchCommand()
	{	
		ifstream origFile = MyConsole::RequestInpFile();
		vector<string> wordsArray = vector<string>();
		string word;
		for (origFile >> word; !origFile.eof(); origFile >> word)
			wordsArray.push_back(word);
	}
}

namespace QuickSort {
	vector<string> Sort(string in) {

	};
}