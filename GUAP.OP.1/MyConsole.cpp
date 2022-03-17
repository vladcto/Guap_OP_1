#include "MyConsole.h"
#include <string>
#include <iostream>
#include <iomanip>
#include"QuickSortCstm.h"

using namespace std;

namespace MyConsole{
	void RunConsole() {
		setlocale(LC_ALL, "Russian");

		ShowString("���� 1");
		ShowString("����: ����������"); 
		ShowString("��������: �������� ����"); 
		ShowSeparator();
		
		QuickSortCommand::LaunchCommand();
	}

	ifstream RequestInpFile()
	{
		return std::ifstream();
	}
	
	void ShowString(string message)
	{
		cout << message << "\n";
	}

	void ShowSeparator() {
		ShowString("-------------------------");
	}

	string RequestString() {
		string res;
		cout << "������� ������: ";
		cin >> res;
		cout << "\n";
		return res;
	}
	std::string RequestString(std::string message)
	{
		ShowString(message);
		return RequestString();
	}
	std::ifstream RequestInpFile(std::string message)
	{
		string filePath = RequestString(message);
		ifstream inputFile(filePath);
		return inputFile;
	}
}