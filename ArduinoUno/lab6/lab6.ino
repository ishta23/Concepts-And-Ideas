#include <Time.h>
#include <TimeLib.h>

#include <stdio.h>
#include <string.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,16,2); // set the LCD address to 0x27 for a 16 chars and 2 line display


// T1262347200  //noon Jan 1 2010
int hr=0;
int min2 =0;
int sec =0;
int day2 =0;
int month2 = 0;
int yr =0;

void setup()  {
  lcd.init(); //initialize the lcd
  lcd.backlight(); //open the backlight 
  Serial.begin(9600);
  Serial.println("Please enter the year:");
  while (!Serial.available() > 0) {}
  yr = rYear();
  Serial.println("Please enter the month (1-12):");
  while (!Serial.available() > 0) {}
  month2 = rMonth();
  Serial.println("Please enter the day (1-31):");
  while (!Serial.available() > 0) {}
  day2 = rDay();
  Serial.println("Please enter the hour (0-23):");
  while (!Serial.available() > 0) {}
  hr = rHour();
  Serial.println("Please enter the minute (0-59):");
  while (!Serial.available() > 0) {}
  min2 = rMin();
  Serial.println("Please enter the seconds (0-59):");
  while (!Serial.available() > 0) {}
  sec = rSec();
  setTime(hr,min2,sec,day2,month2,yr); // Another way to set
}

void loop(){    
  time_t t = now();
  /*Serial.print(hour(t));
  Serial.print(": ");
  Serial.print(minute(t));
  Serial.print(": ");
  Serial.print(second(t));
*/
  lcd.setCursor(0,0);
  lcd.print(month(t));
  lcd.print("/ ");
  lcd.print(day(t));
  lcd.print("/ ");
  lcd.print(year(t));
  lcd.setCursor(0, 1);
  lcd.print(hour(t));
  lcd.print(": ");
  lcd.print(minute(t));
  lcd.print(": ");
  lcd.print(second(t));
  delay(1000);
}
int rYear()
{
  int yearr = Serial.parseInt();
  while(yearr < 0)
  {
    Serial.println("Oops, enter year again: ");
    while(!Serial.available() > 0){}
    yearr = Serial.parseInt();
  }
  Serial.println(yearr, DEC);
  Serial.flush(); //don't forget
  return yearr;
}
int rMonth()
{
  int mmonth = Serial.parseInt();
  while(mmonth < 1 || mmonth > 12)
  {
    Serial.println("Oops, enter month again (1-12): ");
    while(!Serial.available() > 0){}
    mmonth = Serial.parseInt();
  }
  Serial.println(mmonth, DEC);
  Serial.flush(); //don't forget
  return mmonth;
}
int rDay()
{
  int dayy = Serial.parseInt();
  while(dayy < 1 || dayy > 31)
  {
    Serial.println("Oops, enter day again (1-31): ");
    while(!Serial.available() > 0){}
    dayy = Serial.parseInt();
  }
  //february
  if(month2 == 2 || month2 == 4 || month2 ==  6 || month2 == 9 || month2 == 11 ) 
  {
    if(dayy > 28) 
    {
      Serial.println("Oops, enter day again (1-12): ");
       while(!Serial.available() > 0){}
      dayy = Serial.parseInt();
    }
  }
  Serial.println(dayy, DEC);
  Serial.flush(); //don't forget
  return dayy;
}
int rHour()
{
  int hourr = Serial.parseInt();
  while(hourr < (-1) || hourr > 23)
  {
    Serial.println("Oops, enter hour again (0-23): ");
    while(!Serial.available() > 0){}
    hourr = Serial.parseInt();
  }
  Serial.println(hourr, DEC);
  Serial.flush(); //don't forget
  return hourr;
}
int rMin()
{
  int minn = Serial.parseInt();
  while( minn < (-1) || minn > 59)
  {
    Serial.println("Oops, enter minute again (0-59): ");
    while(!Serial.available() > 0){}
    minn = Serial.parseInt();
  }
  Serial.println(minn, DEC);
  Serial.flush(); //don't forget
  return minn;
}
int rSec()
{
  int secc = Serial.parseInt();
  while( secc <  -1 || secc > 60)
  {
    Serial.println("Oops, enter second again (0-59): ");
    while(!Serial.available() > 0){}
    secc = Serial.parseInt();
  }
  Serial.println(secc, DEC);
  Serial.flush(); //don't forget
  return secc;
}

