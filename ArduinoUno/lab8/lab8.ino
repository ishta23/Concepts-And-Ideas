/* Lab 8 2016
 *  by Ishta  Bhagat ibhagat2
 *  & Dania Azhari dazhar2
 *  CS 362, Lab 8
 */
const int myled = 7;  // pushbutton 1 pin
const int myButton = 8;

int a;
int myState = LOW;
int prevState = LOW;

//uint8_t turnON=1;
//uint8_t turnOFF =0;
void setup() {
  
 Serial.begin(9600);
 pinMode(myled, OUTPUT);
 pinMode(myButton, INPUT);
}

void loop() 
{
 myState = digitalRead(myButton);
 if((myState == HIGH) && (prevState == LOW))
 {
  Serial.write(1);
 }
 else 
 {
  Serial.write(0);
 }
 prevState = myState;
 if(Serial.available())
 {
    int a = Serial.read();
    if(a == 1)
    {
      if(turnOn){
      digitalWrite(myled, HIGH);
      turnOn= false;
      }
    }
     else 
    {
      digitalWrite(myled, LOW);
      turnOn = true;
    }
 }
}
