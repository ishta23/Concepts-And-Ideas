#include <stdio.h>
#include <string.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27,16,2); // set the LCD address to 0x27 for a 16 chars and 2 line display

const int button1Pin = 2;  // pushbutton 1 pin
const int button2Pin = 3;  // pushbutton 2 pin
volatile byte button1State = LOW;
volatile byte button2State = LOW;

volatile byte state = 0;
int counter = 0;

void changeStatus1()
{
  state = 1;
}
void changeStatus2()
{
  state = 0; 
}
void setup() {
  Serial.begin(9600);
  pinMode(button1Pin, INPUT_PULLUP);
  pinMode(button2Pin, INPUT_PULLUP);
  
  attachInterrupt(digitalPinToInterrupt(button1Pin), changeStatus1, RISING);
  attachInterrupt(digitalPinToInterrupt(button2Pin), changeStatus2, RISING);
  
  lcd.init(); //initialize the lcd
  lcd.backlight(); //open the backlight 
}

void loop() {
  
  //prints time since program started
  /*button1State = digitalRead(button1Pin);
  button2State = digitalRead(button2Pin);*/
  if(state == 0)
  {
    lcd.setCursor(0,0);
    lcd.print ("Waiting for");
    lcd.setCursor(0,1);
    lcd.print(counter);
    lcd.print("seconds");
    counter++;
  }
  else if (state == 1)
  {
    lcd.setCursor(0,0);
    lcd.print ("Interrupted Pres");
    lcd.setCursor(0,1);
    lcd.print("s Button 2");
    counter = 0;
  }
  delay(1000);
  lcd.clear();
}
