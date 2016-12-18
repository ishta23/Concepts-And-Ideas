const int button1Pin = 2;  // pushbutton 1 pin
const int button2Pin = 3;  // pushbutton 2 pin
const int ledPin =  12;    // LED pin
const int ledPin2= 11;
const int ledPin3= 10;

void setup() {
  // put your setup code here, to run once:
  // Set up the pushbutton pins to be an input:
  pinMode(button1Pin, INPUT);
  pinMode(button2Pin, INPUT);

  // Set up the LED pin to be an output:
  pinMode(ledPin, OUTPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(ledPin3, OUTPUT);     
}

void loop() {
  // put your main code here, to run repeatedly:
  int button1State, button2State;  // variables to hold the pushbutton states
   button1State = digitalRead(button1Pin);
  button2State = digitalRead(button2Pin);
  if (((button1State == LOW) || (button2State == LOW))  // if we're pushing button 1 OR button 2
      && !                                               // AND we're NOT
      ((button1State == LOW) && (button2State == LOW))) // pushing button 1 AND button 2
                                                        // then...
  {
    digitalWrite(ledPin, HIGH);  // turn the LED on
    digitalWrite(ledPin2, HIGH);
    digitalWrite(ledPin3, HIGH);
  }
  else
  {
    digitalWrite(ledPin, LOW);  // turn the LED off
    digitalWrite(ledPin2, LOW);
    digitalWrite(ledPin3, LOW);
  }
}
