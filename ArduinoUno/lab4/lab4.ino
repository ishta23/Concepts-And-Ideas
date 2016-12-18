#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
/**********************************************************/
char array1[]=" Ishta Bhagat"; //the string to print on the LCD
int photocellPin = 0;     // the cell and 10K pulldown are connected to a0
int photocellReading;  

int tim = 250; //the value of delay time
// initialize the library with the numbers of the interface pins
LiquidCrystal_I2C lcd(0x27,16,2); // set the LCD address to 0x27 for a 16 chars and 2 line display
/*********************************************************/
void setup()
{
  lcd.init(); //initialize the lcd
  lcd.backlight(); //open the backlight 
  Serial.begin(9600);
}

void loop() 
{
  photocellReading = analogRead(photocellPin); 
   //Clears the LCD screen and positions the cursor in the upper-left  corner.
    lcd.setCursor(0,0); // set the cursor to column 15, line 0
   if (photocellReading < 100) {
    lcd.print(" Dark");
  } else if (photocellReading < 200) {
    lcd.print("Dim");
  } else if (photocellReading < 500) {
    lcd.print("Light");
  } else if (photocellReading < 800) {
    lcd.print("Bright");
  } else {
    lcd.print("Very bright");
  }
    
    delay(tim); //wait for 250 microseconds
    //lcd.clear();
}
