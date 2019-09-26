
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
//INCLUDE for esp01
#include <SoftwareSerial.h>
SoftwareSerial espSerial =  SoftwareSerial(2,3);      // arduino RX pin=2  arduino TX pin=3    connect the arduino RX pin to esp8266 module TX pin   -  connect the arduino TX pin to esp8266 module RX pin


//Variables for ESP01 communication

String apiKey = "KQXIVPQ0O20SZ18N";     // replace with your channel's thingspeak WRITE API key
String ssid="PLDT_SUCKS";    // Wifi network SSID
String password ="ronaldmanapat";  // Wifi network password
boolean DEBUG=true;

//For Temp sensor
#include <OneWire.h>
#include <DallasTemperature.h> 
#define ONE_WIRE_BUS 4

//for temp sensor ONE_WIRE_BUS = Digital pin 2
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);

//LCD constants
LiquidCrystal_I2C lcd(0x27,20,4);  // set the LCD address to 0x27 for a 16 chars and 2 line display

// LCD Pins A4 and A5



//  Sensor variables
String TempNow, PulseNow, BPNow;

// Pulse sensor constant
const int Pulse = A1;
unsigned long HeartRate;

//Variables for BP
const int pumpPin = 7;
const int valvePin = 6;
const int bp_sensor = A0; //  connected to analog pin 0

int systolic = 0;
int diastolic = 0;
String currentBP = "";
boolean bpDone = false;

float PressureMin = -15;
float PressureMax = 15;
float Vsupply = 5;

int analogPin = A0;
float volta= 0;
int i;
float maxVolt = 0;
int volt = 0;
float pressure = 0;
float MAP = 0;
float maxv = 0;

//Boolean flags
bool doneBP = false;


//======================================SETUP
void setup() {
  lcd.init();
  pinMode(pumpPin, OUTPUT); //  INPUT_PULLUP is used so that we dont have to use pullup resistor
  pinMode(valvePin, OUTPUT);
  
  Serial.begin(9600);
  sensors.begin();
  randomSeed(analogRead(A0));
  lcdPrint("Connecting to         ","Internet...           ");
  //Connection to Internet and ESP01
  DEBUG=true;             // enable debug serial
  espSerial.begin(115200);  // enable software serial
                          // Your esp8266 module's speed is probably at 115200. 
                          // For this reason the first time set the speed to 115200 or to your esp8266 configured speed 
                          // and upload. Then change to 9600 and upload again
  showResponse(1000);
  espSerial.println("AT+RST");         // Enable this line to reset the module;
  showResponse(1000);

  espSerial.println("AT+UART_CUR=9600,8,1,0,0");    // Enable this line to set esp8266 serial speed to 9600 bps
  showResponse(1000);
  espSerial.begin(9600);
  showResponse(1000);
  espSerial.println("AT+CWMODE=1");   // set esp8266 as client
  showResponse(1000);

  espSerial.println("AT+CWJAP=\""+ssid+"\",\""+password+"\"");  // set your home router SSID and password
  showResponse(5000);
 lcdPrint("Connected.      ", "Preparing to BP.  "); //Print this at initialization
 delay(5000);
  if (DEBUG)  Serial.println("Setup completed");
  
  thingSpeakWrite("0","0","0");
  
}
//======================================SETUP
//======================================LOOP
void loop() {

  // put your main code here, to run repeatedly:
  if (doneBP == false){
    lcdPrint("Getting BP.           ","Please Wait..          ");
    get_BP();
    lcdPrint("Finger on Sensor      ","Thank you.             ");
  }
  

  // Get pulse. Delay 10 secs to get average pulse.
  delay(10000);
  get_pulse();

  // Get Temperature. Instantaneous.
  get_temp();

  String first;
  first = "BP: " + BPNow + "         ";
  String second;
  second = "T:" + TempNow + " P: " + PulseNow + "     ";
  lcdPrint(first,second);

  //If Thingspeakwrite is true, Wait for 1 minute for another reading.
  //If False, get another readin except BP.
  if (thingSpeakWrite(TempNow,PulseNow,String(BPNow))){
  // 2 Minute Delay     

  lcdPrint("Sending      ","Success...      ");
  delay(10000);
  lcdPrint("1 Minute        ","to next reading.");
  delay(10000); 
  lcdPrint("50 Seconds        ","to next reading.");
  delay(10000);
  lcdPrint("40 Seconds        ","to next reading.");
  delay(10000); 
  lcdPrint("30 Seconds        ","to next reading.");
  delay(10000); 
  lcdPrint("20 Seconds        ","to next reading.");
  delay(10000); 
  lcdPrint("10 Seconds        ","to next reading.");
  delay(10000); 
  doneBP = false;
  }
  else{
    lcdPrint("Failed Sending.      ","Retrying...      ");
  }
  
}

void get_temp(){
  sensors.requestTemperatures(); // Send the command to get temperatures
  //Serial.print("Temperature is: ");
  //Serial.print(sensors.getTempCByIndex(0)); // Why "byIndex"? 
  TempNow = sensors.getTempCByIndex(0);
    // You can have more than one IC on the same bus. 
    // 0 refers to the first IC on the wire
}

void get_pulse(){
  while (digitalRead(Pulse) == HIGH);
  while (digitalRead(Pulse) == LOW);
  int T1 = millis();
  while (digitalRead(Pulse) == HIGH);
  while (digitalRead(Pulse) == LOW);
  int T2 = millis();
  int Time = T2-T1;
  HeartRate = 60000L;
  HeartRate = HeartRate/Time; 
  //Serial.print("BPM = ");
  //Serial.println(HeartRate);
  PulseNow = HeartRate;
  //delay(1000); 
}

//=========================Gett
void get_BP(){

               digitalWrite(pumpPin, HIGH);
              digitalWrite(valvePin, HIGH);
              delay(25000);
  //get bp code
 for(i =0; i<40; i=i+1){
  volta  = analogRead(analogPin);
  volt = (volta*Vsupply)/(pow(2,10)-1);
  maxv = max(abs(volt-2.5),maxVolt);
  maxVolt = abs(maxv-2.5);
  delay(250);
}
  pressure = (((maxVolt)-.1*Vsupply)/((.8*Vsupply)/(PressureMax-PressureMin)))+PressureMin;
  MAP = -1*(14.7-pressure*-1)*51.7 - 3.16/maxVolt;
  
  
              systolic = MAP*1.1;
              diastolic = MAP*0.8;

              currentBP = String(systolic) + "/" + String(diastolic);
              Serial.println("BP:" + currentBP);
              bpDone = true;
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, LOW);
              delay(100);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, HIGH);
              delay(300);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, LOW);
              delay(100);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, HIGH);
              delay(300);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, LOW);
              delay(100);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, HIGH);
              delay(300);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, LOW);
              delay(100);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, HIGH);
              delay(300);
              digitalWrite(pumpPin, LOW);
              digitalWrite(valvePin, LOW);
              delay(100);
              
              delay(5000);
              doneBP = true;
}


void lcdPrint(String toPrint1, String toPrint2){
  lcd.home (); // set cursor to 0,0
  lcd.print(toPrint1); 
  lcd.setCursor (0,1);        // go to start of 2nd line
  lcd.print(toPrint2);
  lcd.setBacklight(HIGH);     // Backlight on
}

//======================================================================== showResponce
void showResponse(int waitTime){
    long t=millis();
    char c;
    while (t+waitTime>millis()){
      if (espSerial.available()){
        c=espSerial.read();
        if (DEBUG) Serial.print(c);
      }
    }
}

//======================================================================== ThingSpeak SENDING code
boolean thingSpeakWrite(String value1, String value2, String value3){
  String cmd = "AT+CIPSTART=\"TCP\",\"";                  // TCP connection
  cmd += "184.106.153.149";                               // api.thingspeak.com
  cmd += "\",80";
  espSerial.println(cmd);
  if (DEBUG) Serial.println(cmd);
  if(espSerial.find("Error")){
    if (DEBUG) Serial.println("AT+CIPSTART error");
    return false;
  }
  
  
  String getStr = "GET /update?api_key=";   // prepare GET string
  getStr += apiKey;
  
  getStr +="&field1=";
  getStr += String(value1);
  getStr +="&field2=";
  getStr += String(value2);
  getStr +="&field3=";
  getStr += String(value3);
  // getStr +="&field3=";
  // getStr += String(value3);
  // ...
  getStr += "\r\n\r\n";

  // send data length
  cmd = "AT+CIPSEND=";
  cmd += String(getStr.length());
  espSerial.println(cmd);
  if (DEBUG)  Serial.println(cmd);
  
  delay(100);
  if(espSerial.find(">")){
    espSerial.print(getStr);
    if (DEBUG)  Serial.print(getStr);
  }
  else{
    espSerial.println("AT+CIPCLOSE");
    // alert user
    if (DEBUG)   Serial.println("AT+CIPCLOSE");
    return false;
  }
  return true;
}
//=======================================================================
