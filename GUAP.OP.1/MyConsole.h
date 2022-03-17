#include<string>
#include <fstream>

namespace MyConsole {
	void RunConsole();
	std::ifstream RequestInpFile();
	void ShowString(std::string message);
	void ShowSeparator();
	std::string RequestString();
	std::string RequestString(std::string message);
	std::ifstream RequestInpFile(std::string message);
}