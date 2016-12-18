const int button1Pin = 2;  // pushbutton 1 pin
const int button2Pin = 3;  // pushbutton 2 pin
const int ledPin =  12;    // LED pin
const int ledPin2= 11;
const int ledPin3= 10;
 int button1State = LOW;
 int button2State = LOW;  // variables to hold the pushbutton states
 int prevButton1 = HIGH;
 int prevButton2 = HIGH;
 int b1count = 0;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  // Set up the pushbutton pins to be an input:
  pinMode(button1Pin, INPUT);
  pinMode(button2Pin, INPUT);

  // Set up the LED pin to be an output:
  pinMode(ledPin, OUTPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(ledPin3, OUTPUT);     
}
void display(int count)
{
  if(count ==0)
  {
    digitalWrite(ledPin, LOW);  // turn the LED on
    digitalWrite(ledPin2, LOW);
    digitalWrite(ledPin3, LOW);
  }
  else if(count ==1)
  {
    digitalWrite(ledPin, HIGH);  // turn the LED on
    digitalWrite(ledPin2, LOW);
    digitalWrite(ledPin3, LOW);
  }
  else if(count ==2)
  {
    digitalWrite(ledPin, LOW);  // turn the LED on
    digitalWrite(ledPin2, HIGH);
    digitalWrite(ledPin3, LOW);
  }
  else if(count ==3)
  {
    digitalWrite(ledPin, HIGH);  // turn the LED on
    digitalWrite(ledPin2, HIGH);
    digitalWrite(ledPin3, LOW);
  }
  else if(count ==4)
  {
    digitalWrite(ledPin, LOW);  // turn the LED on
    digitalWrite(ledPin2, LOW);
    digitalWrite(ledPin3, HIGH);
  }
  else if(count ==5)
  {
    digitalWrite(ledPin, HIGH);  // turn the LED on
    digitalWrite(ledPin2, LOW);
    digitalWrite(ledPin3, HIGH);
  }
  else if(count ==6)
  {
    digitalWrite(ledPin, LOW);  // turn the LED on
    digitalWrite(ledPin2, HIGH);
    digitalWrite(ledPin3, HIGH);
  }
  else
  {
   digitalWrite(ledPin, HIGH);  // turn the LED on
    digitalWrite(ledPin2, HIGH);
    digitalWrite(ledPin3, HIGH); 
  }
}
void loop() {
  // put your main code here, to run repeatedly:
 
  button1State = digitalRead(button1Pin);
  button2State = digitalRead(button2Pin);
 
  if(button1State != prevButton1)
  {
    if(button1State == HIGH)
    {
      b1count++;
      if(b1count > 7)
      {
      b1count =0;
      }
    }
    else 
    {
      Serial.println("OFF");
    }
    delay(50);
  }
  prevButton1 = button1State;
  if(button2State != prevButton2)
  {
    if(button2State == HIGH)
    {
      b1count--;
      if(b1count < 0 )
      {
        b1count =7;
      }
    }
    else 
    {
      Serial.println("OFF");
    }
    delay(50);
  }
  prevButton2 = button2State;
  display(b1count);  
}


