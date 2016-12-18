//Author: Ishta Bhagat
//U. of Illinois, Chicago
//CS341, Spring 16
//HW #3
#include "stdafx.h"
#include <iostream>
#include <stdexcept>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>
#include <algorithm>

using namespace std;

class Stop {
public:
	std::string stopName;
	string direction;
	bool handicap;
	std::vector<std::string> lines;
	Stop::Stop(string name, string dir, bool disability, vector<string> tab) : stopName(name), direction(dir), handicap(disability), lines(tab){}
	//Convert the TRUE string to bool and FALSE to bool 
	bool convert(std::string decide)
	{
		if (decide == "TRUE")
		{
			return true;
		}
		else
			return false;
	}

};
class Station {
public:
	int          ID;
	std::string  Name;
	int          Stops;
	long long    Ridership_Weekday;
	long long    Ridership_Saturday;
	long long    Ridership_SundayHoliday;
	std::vector<Stop> lineStops;
	//
	// Constructs a new station with 1 sto
	//
	Station::Station(int id, std::string name)
		: ID(id), Name(name), Stops(1),
		Ridership_Weekday(0), Ridership_Saturday(0), Ridership_SundayHoliday(0)
	{ }

	//
	// Number of stops at this station:
	//
	int Station::NumStops() const
	{
		return Stops;
	}

	//
	// Based on day type (W, A or U), add # of rides to appropriate total:
	//
	void Station::UpdateRidership(std::string day_type, int rides)
	{
		if (day_type == "W")
			Ridership_Weekday += rides;
		else if (day_type == "A")
			Ridership_Saturday += rides;
		else if (day_type == "U")
			Ridership_SundayHoliday += rides;
		else
			throw std::invalid_argument("invalid day_type in UpdateRidership");
	}

	//
	// Total ridership across all day types:
	//
	// NOTE: long long => 64-bit result
	//
	long long Station::TotalRidership() const
	{
		return Ridership_Weekday +
			Ridership_Saturday +
			Ridership_SundayHoliday;
	}
};

//
// InputStations:
//
std::vector<Station> InputStations(std::string filename, int& stopCount)
{
	std::vector<Station>  stations;
	std::ifstream         file(filename.c_str());
	std::string           line;

	if (!file.good())
		throw std::invalid_argument("file '" + filename + "' not found!");

	std::cout << "Inputting data ... "
		<< endl;

	std::getline(file, line);  // discard first line: column headers

							   //
							   // Input the data line by line, creating Station objects and storing them 
							   // into a vector:
							   //
	while (std::getline(file, line))
	{
		std::stringstream  ss(line);

		std::string  station_id, direction, stop_name, station_name, handicap, red, blue, green, brown, purple, purpleExp, yellow, pink, orange;

		std::getline(ss, station_id, ',');
		std::getline(ss, direction, ',');
		std::getline(ss, stop_name, ',');
		std::getline(ss, station_name, ',');
		std::getline(ss, handicap, ',');
		std::getline(ss, red, ',');
		std::getline(ss, blue, ',');
		std::getline(ss, green, ',');
		std::getline(ss, brown, ',');
		std::getline(ss, purple, ',');
		std::getline(ss, purpleExp, ',');
		std::getline(ss, yellow, ',');
		std::getline(ss, pink, ',');
		std::getline(ss, orange);
		//add stops 
		stopCount++;
		//create the stop and initialize 
		//some how add to stops vector in Station 


		int id = std::stoi(station_id);

		//
		// see if station is already created in the vector:
		//
		auto result = std::find_if(stations.begin(), stations.end(),
			[=](const Station& S)
		{
			if (S.ID == id)  // station already in vector:
				return true;
			else
				return false;
		}
		);

		// Add station to vector if not already there:
		//
		if (result == stations.end())  // not there, so add:
		{
			Station station(id, station_name);

			std::vector<std::string> linesAvailable;
			linesAvailable.push_back(red); linesAvailable.push_back(blue); linesAvailable.push_back(green); linesAvailable.push_back(brown);
			linesAvailable.push_back(purple); linesAvailable.push_back(purpleExp); linesAvailable.push_back(yellow); linesAvailable.push_back(pink);
			linesAvailable.push_back(orange);
			//convert to bool for handicap accessible or not 
			bool handicap2 = false;
			if (handicap == "TRUE")
			{
				handicap2 = true;
			}
			else
				handicap2 = false;
			
			Stop stop(stop_name, direction, handicap2, linesAvailable);
			station.lineStops.push_back(stop);
			

			stations.push_back(station);
			station.Stops++;
		}
		else  // station exists, but we have another stop:
		{
			Station s = *result;
			vector<string> linesAvailable;
			linesAvailable.push_back(red); linesAvailable.push_back(blue); linesAvailable.push_back(green); linesAvailable.push_back(brown);
			linesAvailable.push_back(purple); linesAvailable.push_back(purpleExp); linesAvailable.push_back(yellow); linesAvailable.push_back(pink);
			linesAvailable.push_back(orange);
			bool handicap2 = false;
			if (handicap == "TRUE")
			{
				handicap2 = true;
			}
			else
				handicap2 = false;
			Stop stop(stop_name, direction, handicap2, linesAvailable);

			s.lineStops.push_back(stop);
			s.Stops++;
			*result = s;
			

		}
	}//while
	 //
	 // Done, return vector of stations back to caller:
	 //
	return stations;
}
//
// InputRidership:
//
void InputRidership(std::string filename, std::vector<Station>& stations)
{
	std::ifstream  file(filename.c_str());
	std::string    line;

	if (!file.good())
		throw std::invalid_argument("file '" + filename + "' not found!");


	std::getline(file, line);  // discard first line: column headers

							   //
							   // Input the data line by line, incorporating each line of ridership data
							   // into the appropriate Station object:
							   //
	while (std::getline(file, line))
	{
		std::stringstream  ss(line);

		std::string  station_id, service_date, day_type, total_rides;

		std::getline(ss, station_id, ',');
		std::getline(ss, service_date, ',');
		std::getline(ss, day_type, ',');
		std::getline(ss, total_rides);  // last one, no following ','

		int id = std::stoi(station_id);

		//
		// Search vector of stations to see if this station exists:
		//
		auto result = std::find_if(stations.begin(),
			stations.end(),
			[&](const Station& S)
		{
			if (S.ID == id)
				return true;
			else
				return false;
		}
		);

		// update station ridership if we found it:
		if (result == stations.end())  // not found, so ignore:
		{
			//cout << "Station not found: " << id << endl;
		}
		else  // station exists, update station's ridership info:
		{
			int rides = std::stoi(total_rides);

			result->UpdateRidership(day_type, rides);
		}
	}//while

}

void colorLineProcess(string filename, vector<Station>& stations, const long long total)
{
	vector<Station> LineStations;
	std::ifstream  file(filename.c_str());
	std::string    line;
	int numLines = 0;
	long long weekday =0;
	long long saturday = 0;
	long long sunday = 0;

	if (!file.good())
		throw std::invalid_argument("file '" + filename + "' not found!");
	while (std::getline(file, line))
	{
		std::stringstream ss(line);

		std::string  id;

		std::getline(ss, id);

		int id2 = std::stoi(id);
		numLines++;
		//
		// Search vector of stations to see if this station exists:
		//
		auto result = std::find_if(stations.begin(),
			stations.end(),
			[=](const Station& S)
			{
			if (S.ID == id2)
				return true;
			else
				return false;
			}
		);

		//
		// update station ridership if we found it:
		//
		if (result == stations.end())  // not found, so ignore:
		{
			//cout << "Station not found: " << id << endl;
		}
		else  // station exists
		{
			LineStations.push_back(*result);
			Station temp = *result;
			weekday = weekday + temp.Ridership_Weekday;
			saturday = saturday + temp.Ridership_Saturday;
			sunday = sunday + temp.Ridership_SundayHoliday;
		}
	}//while
	////add the riderships total 
	//Give the stats
	std::cout << "**Line contains " << numLines << " stations" << endl;
	std::cout << "**Weekday ridership: " << weekday << endl;
	std::cout << "**Saturday ridership: " << saturday << endl;
	std::cout << "**Sunday/Holiday: " << sunday << endl;

	//NOT WORKING 
	double long percentage = (weekday + saturday + sunday);
	percentage = (percentage / total);
	std::cout << "% of Total riderships: " << (percentage*100) << endl;
	int i = 1;
	for (Station& s : LineStations) 
	{
		std::cout << i << "." << s.Name<< endl;
		for (Stop& a : s.lineStops)//in vector that contains all the stops 
		{
			string handi = "";
			std::cout <<"\t"<< a.stopName << ": " << a.direction << ", ";
			if (a.handicap == true)
			{
				handi = "Handicap access";
			}
			else
			{
				handi = "*no* Handicap access";
			}
			std::cout << handi;
			for (int i = 0; i < a.lines.size(); i++)
			{
				if (a.lines[i] == "TRUE")
				{
					if(i == 0)
						std::cout << "," << "Red";
					if (i == 1)
						std::cout << "," << "Blue";
					if (i == 2)
						std::cout << "," << "Green";
					if (i == 3)
						std::cout << "," << "Brown";
					if (i == 4)
						std::cout << "," << "Purple";
					if (i == 5)
						std::cout << "," << "Purple Express";
					if (i == 6)
						std::cout << "," << "Yellow";
					if (i == 7)
						std::cout << "," << "Pink";
					if (i == 8)
						std::cout << "," << "Orange";
				}
			}
			std::cout << " " << endl;
		}
		i++;
	}




}
//
// main:
//
int main()
{
	std::cout << "** CTA L Ridership Analysis Program **" << endl;
	std::cout << endl;

	//
	// First, input the station & stop data:
	//
	std::vector<Station>  stations;
	int stopCount=0;
	vector<Station> stationLines;

	stations = InputStations("CTA-L-Stops.csv", stopCount);

	std::cout << "Num stations: " << stations.size() << endl;

	//int stops = 0;

	//for (const Station& S : stations)
	//{
		// cout << s.ID << ": " << s.Name << endl;
	//	stops += S.NumStops();
	//}

	std::cout << "Num stops:    " << stopCount << endl;

	//
	// Now input the ridership data, updating stations to include
	// this data:
	//
	InputRidership("CTA-L-Ridership-Daily.csv", stations);

	long long total_ridership = 0;

	for (const Station& S : stations)
	{
		total_ridership += S.TotalRidership();
	}
	std::cout << "Total ridership: " << total_ridership << " (CTA-L-Ridership-Daily.csv)"<<endl;
	std::cout << endl;
	std::cout << "**Ready" << endl;
	string color;

	//start asking the question loop
	std::cout << ">> Please enter an L Line(e.g Blue), or ENTER to quit: ";
	getline(cin, color);

	while (color !="")
	{
		if(color =="Blue")
		{
			colorLineProcess("Blue.txt", stations, total_ridership);
			
		}
		else if (color == "Pink")
		{
			colorLineProcess("Pink.txt", stations, total_ridership);
		}
		else if (color == "Red")
		{
			colorLineProcess("Red.txt", stations, total_ridership);
		}
		else if (color == "Yellow")
		{
			colorLineProcess("Yellow.txt", stations, total_ridership);
		}
		else
		{
			std::cout << "**Error: unable to open '" << color << ".txt', incorrect L line?" << endl;
			std::cout << "**Please try again..." << endl;
		}
		//start asking the question loop
	std::cout << ">> Please enter an L Line(e.g Blue), or ENTER to quit: ";
	getline(cin, color);

	}
	std::cout << "** Done **" << endl;
	return 0;
}