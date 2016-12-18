#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
/**********************************************************/
char array1[]=" Ishta Bhagat"; //the string to print on the LCD
char array2[40]="When people see good, they expect good. "; //the string to print on the LCD
char array3[16] = "";
int pos = 0;
int count = 0;
int posEnd=16;
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
/*********************************************************/
void getAr()
{
  int i =0;
 
    //to write to array3
    for(i = 0; i < 16; i++) {
        array3[i] = array2[pos]; 
        pos+=1;
        if(pos == 39) 
        {
          pos = 0;
        }
     }
     count++;
     pos = count;
     if(count == 39)
     {
      count =0;
     }
    
}
void loop() 
{
  /*for (int positionCounter1 = 0; positionCounter1 < 12; positionCounter1++)
  {
    //lcd.scrollDisplayLeft(); //Scrolls the contents of the display one space to the left.
    lcd.print(array1[positionCounter1]); // Print a message to the LCD.
    delay(tim); //wait for 250 microseconds
  }*/
   //Clears the LCD screen and positions the cursor in the upper-left  corner.
    lcd.setCursor(0,0); // set the cursor to column 15, line 0
    lcd.print(array1);
    
    getAr();
    lcd.setCursor(0,1); // set the cursor to column 15, line 1
    lcd.print(array3); // Print a message to the LCD.
    delay(tim); //wait for 250 microseconds
    lcd.clear();
}
