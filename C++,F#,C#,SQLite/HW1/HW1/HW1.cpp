//Exam Score Analyis
//Author: Ishta Bhagat
//Group: UIC, Chicago 
//CS341, Spring 2016
//HW #1 

#include "stdafx.h"
#include <iostream>
#include <iomanip>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;
class Student
{
public:
	string name;
	int midtermGrade;
	int finalGrade;
	//Constructor
	Student(string Name, int midterm, int finale)
		:name(Name), midtermGrade(midterm), finalGrade(finale) {}
	//calculate exam average 
	double examAvg()
	{
		return ((midtermGrade + finalGrade) / 2.0);
	}

};


int main()
{
	string line, name;
	int midG, finalG;
	vector<Student> pupils;
	int input; //option user chose
	fstream file("exams.txt");

	if (!file.good())
	{
		cout << "file not found!" << endl;
		return 0;
	}

	while (getline(file, line))
	{
		stringstream readIn(line);
		readIn >> name;
		readIn >> midG;
		readIn >> finalG;

		Student S(name, midG, finalG);
		pupils.push_back(S);
	}
	//print it the order 
	cout << "** Welcome to Exam Analysis Program**" << endl;
	bool done = true;
	while (done) 
	{
		cout << "What type of analysis would you like?" << endl;
		cout << "1. By Name \n" << "2. By exam average \n"
			<< "3. By midterm \n" << "4. By final \n" << endl;
		cin >> input;
		
		if ((input < 1) || (input > 4))
			done = false;
		if (input == 1)
		{
			sort(pupils.begin(), pupils.end(),
				[](Student one, Student two)
			{
				if (one.name <= two.name)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			);
			cout << "Name:  Exam Average" << endl;
			for (Student a : pupils)
			{
				cout << a.name << ":\t" << a.examAvg() << endl;
			}

		}
		else if (input == 2)
		{
			sort(pupils.begin(), pupils.end(),
				[](Student one, Student two)
			{
				if (one.examAvg() > two.examAvg())
				{
					return true;
				}
				else if (one.examAvg() < two.examAvg())
				{
					return false;
				}
				else
				{
					if (one.name <= two.name)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			);
			cout << "Name:  Exam Average" << endl;
			for (Student a : pupils)
			{
				cout << a.name << ":\t" << a.examAvg() << endl;
			}
		}
		else if (input == 3)
		{
			sort(pupils.begin(), pupils.end(),
				[](Student one, Student two)
			{
				if (one.midtermGrade > two.midtermGrade)
				{
					return true;
				}
				else if (one.midtermGrade < two.midtermGrade)
				{
					return false;
				}
				else
				{
					if (one.name <= two.name)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			);
			cout << "Name:  Midterm  Final" << endl;
			for (Student a : pupils)
			{
				cout << a.name << ":\t" << a.midtermGrade << "\t" << a.finalGrade << endl;
			}
		}
		else if(input == 4)
		{
			sort(pupils.begin(), pupils.end(),
				[](Student one, Student two)
			{
				if (one.finalGrade > two.finalGrade)
				{
					return true;
				}
				else if (one.finalGrade < two.finalGrade)
				{
					return false;
				}
				else
				{
					if (one.name <= two.name)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			);
			cout << "Name:  Midterm  Final" << endl;
			for (Student a : pupils)
			{
				cout << a.name << ":\t" << a.midtermGrade << "\t" << a.finalGrade << endl;
			}
		}
		



	}//end while loop for asking, sort, and print 

 } //end main

