//Audio in with 38.5kHz sampling rate, interrupts, and clipping indicator
//by Amanda Ghassaei
//https://www.instructables.com/id/Arduino-Audio-Input/
//Sept 2012

/*
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
*/

#include <ArduinoUniqueID.h>


//variable to store incoming audio sample
int incomingAudio;

int button1=0;
int button1statechanged=0;
int button2=0;
int button2statechanged=0;
int button3=0;
int button3statechanged=0;

int threshold = 512;

const int button1Pin=36;
const int button1Led=34;
const int button2Pin=40;
const int button2Led=38;
const int button3Pin=44;
const int button3Led=42;

const int fader1=A2;
const int fader2=A3;
String sUID="";
//char cmdstr;

const byte numChars = 80;
char incomingBytes[80];
char tempChars[numChars];
boolean newData = false;
//int lf = 10;
char messageFromPC[numChars] = {0};
char messageData[numChars] = {0};
int integerFromPC = 0;

void setup(){
  Serial.begin(115200);
  
  pinMode(button1Pin,INPUT);
  pinMode(button1Led,OUTPUT);
  pinMode(button2Pin,INPUT);
  pinMode(button2Led,OUTPUT);
  pinMode(button3Pin,INPUT);
  pinMode(button3Led,OUTPUT);
  
  //UniqueIDdump(Serial);
  //Serial.print("UID:");
  for (size_t i = 0; i < 3; i++)
  {
    if (UniqueID8[i] < 0x10)
      //Serial.print("0");
      sUID = sUID + "0";
    //Serial.print(UniqueID8[i], HEX); // UID:6E756E6B776F000605
    sUID = sUID + UniqueID8[i];
    //Serial.print("");
  }
  
  //Serial.println();
  //Serial.println("Setup complete");
  //Serial.println(sUID); // 011001170110010701190111000605
  //Serial.println();
  //Serial.println("UID," + sUID + "," + messageData);
  //if you want to add other things to setup(), do it here

}

void loop(){
  recvWithEndMarker();
  if (newData == true) {
        //Serial.print("This just in ... ");
        //Serial.println(incomingBytes);
        

        strcpy(tempChars, incomingBytes);
        parseData();
        //showParsedData();
        
        //Serial.println(incomingBytes);
        //cmdstr = strtok(incomingBytes,",");
        //Serial.println(strcmp(cmdstr,"UID"));
        //Serial.println(cmdstr);
        if(strcmp(messageFromPC,"UID")==0) {
          
          Serial.println("UID," + sUID + "," + messageData);
        }
        newData = false;
    }


  incomingAudio = analogRead(A0);

  // Button 1
  if (button1statechanged != digitalRead(button1Pin)) {
    button1statechanged = digitalRead(button1Pin);
    if (button1statechanged == HIGH){
      // state changed
      if (button1 == 0) { 
        button1 = 1;
        Serial.println("Button 1 On");
      } else {
        button1 = 0;
        Serial.println("Button 1 Off");
      }
    digitalWrite(button1Led, button1);
    }
    
  }
  //Button 2
  if (button2statechanged != digitalRead(button2Pin)) {
    button2statechanged = digitalRead(button2Pin);
    if (button2statechanged == HIGH){
      // state changed
      if (button2 == 0) { 
        button2 = 1;
      } else {
        button2 = 0;
      }
    digitalWrite(button2Led, button2);
    }
  }
  //Button 3
  if (button3statechanged != digitalRead(button3Pin)) {
    button3statechanged = digitalRead(button3Pin);
    if (button3statechanged == HIGH){
      // state changed
      if (button3 == 0) { 
        button3 = 1;
      } else {
        button3 = 0;
      }
    digitalWrite(button3Led, button3);
    }
  }
  
  if(incomingAudio != 0 )
  {
     //Serial.println(incomingAudio);
    if(incomingAudio > threshold) // check if audio signal goes above threshold
    { // 500 is no audio
      //Serial.print("AVU," + incomingAudio);
      char buf[60];
      char buflat[7];
      strcpy(buf, "AVU,");
      strcat(buf, dtostrf(incomingAudio, 4, 0, buflat));
      Serial.println(buf);
      //digitalWrite(13,HIGH);
    } else {
      //digitalWrite(13,LOW);
    }

  }

  delay(50);
}
void recvWithEndMarker() {
    static byte ndx = 0;
    char endMarker = '\n';
    char rc;
    
    while (Serial.available() > 0 && newData == false) {
        rc = Serial.read();

        if (rc != endMarker) {
            incomingBytes[ndx] = rc;
            ndx++;
            if (ndx >= numChars) {
                ndx = numChars - 1;
            }
        }
        else {
            incomingBytes[ndx] = '\0'; // terminate the string
            ndx = 0;
            newData = true;
        }
    }
}
void parseData() {      // split the data into its parts
  
    char * strtokIndx; // this is used by strtok() as an index

    strtokIndx = strtok(tempChars,",");      // get the first part - the string
    strcpy(messageFromPC, strtokIndx); // copy it to messageFromPC
 
    strtokIndx = strtok(NULL,",");      // this continues where the previous call left off
    strcpy(messageData, strtokIndx); // copy it to messageFromPC
    //strtokIndx = strtok(NULL, ",");
    //integerFromPC = atoi(strtokIndx);     // convert this part to an integer


}
void showParsedData() {
  
    Serial.print("Message ");
    Serial.println(messageFromPC);
    Serial.print("Message data ");
    Serial.println(messageData);
}
