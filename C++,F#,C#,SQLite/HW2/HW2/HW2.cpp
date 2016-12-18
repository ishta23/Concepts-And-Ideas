// CTA "L" RidershipAnalysis: main programfile
// Author: Ishta Bhagat
// U. of Illinois, Chicago
// CS341, Spring 2016
// HW #2

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;

class Station {
	public: 
		int stat_id;
		string name;
		int U; //Sunday/Holiday
		int A; //Saturday
		int W; //weekday
		Station(int id, string nAme) : stat_id(id), name(nAme), U(0), W(0), A(0){}
};
vector<Station> sorter(const vector<Station>& a, string day)
{
	vector<Station> tmp(a);
	std::sort(tmp.begin(), tmp.end(),
		[day](const Station& x, const Station& y)
		{
			if (day.compare("U") ==0)
			{
				if (x.U > y.U)
					return true;
				else
					return false; //if y is bigger than x or they are equal 
			}
			else if (day.compare("W") ==0)
			{
				if (x.W > y.W)
					return true;
				else
					return false; //if y is bigger than x or they are equal 
			}
			else if (day.compare("A")==0)
			{
				if (x.A > y.A)
					return true;
				else
					return false; //if y is bigger than x or they are equal 
			}
		});
	return tmp;
}
void file_processor(string fileName, vector<Station>& station_holder)
{
	fstream file(fileName.c_str());
	string line;
	int stopsCount = 0;
	if (!file.good()) 
		throw invalid_argument("file " + fileName + "not found!");
	getline(file, line); //discard first line 
	cout << "Inputting stations and stops from 'CTA-L-Stops.csv'... \t" << endl;
	while (getline(file, line))
	{
		stringstream ss(line);
		string station_id, direction, stop_name, station_name, junk;
		getline(ss, station_id, ',');
		getline(ss, junk, ',');
		getline(ss, junk, ',');
		getline(ss, station_name, ',');
		getline(ss, junk);
		stopsCount++;

		int idInt = std::stoi(station_id);
		Station tmp (idInt, station_name);
		//search if already in vector 
		auto res = find_if(station_holder.begin(), station_holder.end(),
			[idInt](Station& id){
			if (id.stat_id == idInt)
				return true;
			else
				return false;
		  });

		if (res != station_holder.end())
		{
			;
		}
		else
			station_holder.push_back(tmp);
	}
	
	//output it
	cout << "Num stations: " << station_holder.size() << endl;
	cout << "Num stops: " << stopsCount << endl;
	cout << endl;
}
void file_processor2(string fileName, vector<Station>& stationVector)
{
	fstream file(fileName.c_str());
	string line;
	long total_rides = 0;
	if (!file.good())
		throw invalid_argument("file " + fileName + "not found!");
	getline(file, line); //discard first line 
	cout << "Inputting stations and stops from 'CTA-L-Ridership-Daily-2weeks.csv'..." << endl;
	while (getline(file, line))
	{
		stringstream ss(line);
		string station_id, junk, day,riderships;
		getline(ss, station_id, ',');
		getline(ss, junk, ',');
		getline(ss, day, ',');
		getline(ss, riderships);
		int idInt = std::stoi(station_id);
		int ridershipsNum = std::stoi(riderships);
		auto res = find_if(stationVector.begin(), stationVector.end(), 
			[idInt](Station& id) 
		{
			if (idInt == id.stat_id)
				return true;
			else
				return false;
		}
		);
		if (res != stationVector.end())
		{
			total_rides = total_rides + ridershipsNum;
			if (day.compare("U") == 0)
			{
				(*res).U += ridershipsNum;
			}
			else if (day.compare("W") == 0)
			{
				(*res).W += ridershipsNum;
			}
			else if (day.compare("A") == 0)
			{
				(*res).A += ridershipsNum;
			}
		}
	}
	cout << "Total ridership: " << total_rides << endl;
	cout << endl;
}
int main()
{
	cout << "**CTA L Ridership Analysis Program **" << endl;
	cout << endl;
	vector<Station> station_holder;

	file_processor("CTA-L-Stops.csv", station_holder);
	file_processor2("CTA-L-Ridership-Daily-2weeks.csv", station_holder);

	//sorted for 
	vector<Station> weekdaySort = sorter(station_holder, "W");
	vector<Station> saturdaySort = sorter(station_holder, "A");
	vector<Station> sundaySort = sorter(station_holder, "U");

	//print outputs 
	cout << "Top-5 Ridership on Weekdays:" << endl;
	for (int i = 0; i < 5; i++)
	{

		cout << (i + 1) << ". " << weekdaySort[i].name << ":" << weekdaySort[i].W << endl;
	}
	cout << endl;
	cout << "Top-5 Ridership on Saturday:" << endl;
	for (int i = 0; i < 5; i++)
	{

		cout << (i + 1) << ". " << saturdaySort[i].name << ":" << saturdaySort[i].A << endl;
	}
	cout << endl;
	cout << "Top-5 Ridership on Sunday/Holiday:" << endl;
	for (int i = 0; i < 5; i++)
	{

		cout << (i + 1) << ". " << sundaySort[i].name << ":" << sundaySort[i].U << endl;
	}
	cout << endl;
	return 0;
}
