const int ledPin =  7;    // LED pin
const int ledPin2= 8;
const int ledPin3= 9;
const int ledPin4 = 10;

int photocellReading;
int speakerPin = 3;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  // Set up the LED pin to be an output:
  pinMode(ledPin, OUTPUT);
  pinMode(ledPin2, OUTPUT);
  pinMode(ledPin3, OUTPUT);
  pinMode(ledPin4, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

   photocellReading = analogRead(A0);
   Serial.println(photocellReading);
   int sensorValue = analogRead(A1); // 0 – 1023
  analogWrite(speakerPin, sensorValue/4);  
   if (photocellReading < 50) {
    digitalWrite(ledPin, HIGH);
   digitalWrite(ledPin2, HIGH);
   digitalWrite(ledPin3, HIGH);
   digitalWrite(ledPin4, HIGH); 
  } 
  else if (photocellReading < 70) {
    
   digitalWrite(ledPin, HIGH);
   digitalWrite(ledPin2, HIGH);
   digitalWrite(ledPin3, HIGH);
   digitalWrite(ledPin4, LOW); 
  } else if (photocellReading < 100) {
    digitalWrite(ledPin, HIGH);
   digitalWrite(ledPin2, HIGH);
   digitalWrite(ledPin3, LOW);
   digitalWrite(ledPin4, LOW); 
  } else if (photocellReading < 200) {
    digitalWrite(ledPin, HIGH);
   digitalWrite(ledPin2, LOW);
   digitalWrite(ledPin3, LOW);
   digitalWrite(ledPin4, LOW); 
  } else {
   digitalWrite(ledPin, LOW);
   digitalWrite(ledPin2, LOW);
   digitalWrite(ledPin3, LOW);
   digitalWrite(ledPin4, LOW); 
  }
}
