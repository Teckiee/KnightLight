/*************************************************************************************************************
*
* Title			    : Example DMX Muxer with channel patch for Arduino 4 universes DMX library. 
* Version		    : v 0.3
* Last updated	            : 07.07.2012
* Target		    : Arduino mega 2560, Arduino mega 1280
* Author                    : Toni Merino - merino.toni at gmail.com
* Web                       : www.deskontrol.net/blog
*
*https://forum.arduino.cc/t/dmx-master-all-channels-dimmer-fader/344710/9
*
**************************************************************************************************************/
#include "lib_dmx.h"  // comment/uncomment #define USE_UARTx in lib_dmx.h as needed
#include <ArduinoUniqueID.h>

// This sample get the first 200 channels from universe 1 + the first 200 channels from universe 2, and write all
// to universe 3 (addresses 1-200 from universe 2 are converted to 201-400)

//*********************************************************************************************************
//                        New DMX modes *** EXPERIMENTAL ***
//*********************************************************************************************************
#define    DMX512     (0)    // (250 kbaud - 2 to 512 channels) Standard USITT DMX-512
//#define    DMX1024    (1)    // (500 kbaud - 2 to 1024 channels) Completely non standard - TESTED ok
//#define    DMX2048    (2)    // (1000 kbaud - 2 to 2048 channels) called by manufacturers DMX1000K, DMX 4x or DMX 1M ???
#define dmxCount 512                  // Number of RX/TX channels
#define faderPin A0                   // Fader input

#define FreezeLEDRed 44 // 25
#define FreezeLEDGreen 45 // 24
#define FreezeLEDBlue 46 // 22

#define FreezeButton 43

String sUID="";
const byte numChars = 80;
char incomingBytes[80];
char tempChars[numChars];
boolean newData = false;
//int lf = 10;
char messageFromPC[numChars] = {0};
char messageData[numChars] = {0};
int integerFromPC = 0;

unsigned long previousMillis = 0;
const long interval = 75;

void setup() 
{
  Serial.begin(115200);
  //pinMode(13,OUTPUT);                 // Turn off the internal LED
  //digitalWrite(13,LOW);
  pinMode(FreezeLEDRed,OUTPUT);
  pinMode(FreezeLEDGreen,OUTPUT);
  pinMode(FreezeLEDBlue,OUTPUT);
  
  
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
  
  
  ArduinoDmx1.set_control_pin(2);   // Arduino output pin for MAX485 input/output control (connect to MAX485-1 pins 2-3) 
  ArduinoDmx2.set_control_pin(3);   // Arduino output pin for MAX485 input/output control (connect to MAX485-2 pins 2-3) 
  ArduinoDmx3.set_control_pin(4);   // Arduino output pin for MAX485 input/output control (connect to MAX485-3 pins 2-3) 
  
  ArduinoDmx1.set_tx_address(1);    // set tx1 start address
  ArduinoDmx2.set_tx_address(1);    // set tx2 start address
  ArduinoDmx3.set_tx_address(1);    // set tx3 start address
  
  ArduinoDmx1.set_tx_channels(dmxCount); // 2 to 2048!! channels in DMX1000K (512 in standard mode) See lib_dmx.h  *** new *** EXPERIMENTAL
  ArduinoDmx2.set_tx_channels(dmxCount); // 2 to 2048!! channels in DMX1000K (512 in standard mode) See lib_dmx.h  *** new *** EXPERIMENTAL
  ArduinoDmx3.set_tx_channels(dmxCount); // 2 to 2048!! channels in DMX1000K (512 in standard mode) See lib_dmx.h  *** new *** EXPERIMENTAL
  
  // New parameter needed: DMX Mode
  ArduinoDmx1.init_tx(DMX512);    // starts universe 1 as tx, standard DMX 512 - See lib_dmx.h, now support for DMX faster modes (DMX 1000K)
  ArduinoDmx2.init_tx(DMX512);    // starts universe 2 as tx, standard DMX 512 - See lib_dmx.h, now support for DMX faster modes (DMX 1000K)
  ArduinoDmx3.init_tx(DMX512);    // starts universe 3 as tx, standard DMX 512 - See lib_dmx.h, now support for DMX faster modes (DMX 1000K)
  Serial.println("Startup Complete");
  
}//end setup()

void loop()
{
  unsigned long currentMillis = millis();
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
          //digitalWrite(FreezeLEDGreen, 255);
        }
        else if (strcmp(messageFromPC,"DMX")==0) {
          // DMX,Uni,Chan,Val
          //char parsedata[numChars] = {0};
          //char * strtokIndx; // this is used by strtok() as an index
          int iUniverse;
          int iChannel;
          int iUCVal;
          /*
          strtokIndx = strtok(messageData,",");      // get the first part - the string
          Serial.println(strtokIndx);
          strcpy(parsedata, strtokIndx); // copy it to messageFromPC
          Serial.println(parsedata);
          iUniverse = atoi(parsedata);

          strtokIndx = strtok(NULL,",");      // get the first part - the string
          strcpy(parsedata, strtokIndx); // copy it to messageFromPC
          iChannel = atoi(parsedata);

          strtokIndx = strtok(NULL,",");      // get the first part - the string
          strcpy(parsedata, strtokIndx); // copy it to messageFromPC
          iUCVal = atoi(parsedata);
          */
          //Serial.println (messageFromPC);
          //Serial.println (messageData);
          char* splitData = strtok(messageData, "|");
          iUniverse = atoi(splitData);
          //Serial.println (iUniverse);
          splitData = strtok(NULL, "|");
          iChannel = atoi(splitData)-1;
          //Serial.println (iChannel);
          splitData = strtok(NULL, "|");
          iUCVal = atoi(splitData);
          //Serial.println (iUCVal);
          
          //Serial.println (iUniverse);
          if(iUniverse == 1) {
            ArduinoDmx1.TxBuffer[iChannel] = iUCVal;
            digitalWrite(FreezeLEDBlue, 255);
            previousMillis = millis();
            //Serial.println ("Gotem");
          } else if(iUniverse == 2) {
            ArduinoDmx2.TxBuffer[iChannel] = iUCVal;
            digitalWrite(FreezeLEDBlue, 255);
            previousMillis = millis();
            //Serial.println ("Gotem");
          } else if(iUniverse == 3) {
            ArduinoDmx3.TxBuffer[iChannel] = iUCVal;
            digitalWrite(FreezeLEDBlue, 255);
            previousMillis = millis();
            //Serial.println ("Gotem");
          }
        }
        
        newData = false;
    }


    
  //ArduinoDmx1.TxBuffer[0] = 0;
  //ArduinoDmx1.TxBuffer[1] = 1023;
  //ArduinoDmx1.TxBuffer[2] = 0;
  //ArduinoDmx1.TxBuffer[3] = 0;
  //ArduinoDmx2.TxBuffer[0] = 0;
  //ArduinoDmx2.TxBuffer[1] = 1023;
  //ArduinoDmx2.TxBuffer[2] = 1023;
  //ArduinoDmx2.TxBuffer[3] = 0;
  //ArduinoDmx2.TxBuffer[4] = 0;
  //ArduinoDmx2.TxBuffer[5] = 0;
  //ArduinoDmx2.TxBuffer[6] = 0;
  //digitalWrite(FreezeLEDRed, 0);
  //digitalWrite(FreezeLEDBlue, 255);
  //Serial.println("loop 1");
  //delay(100);
  //ArduinoDmx1.TxBuffer[0] = 1023;
  //ArduinoDmx1.TxBuffer[1] = 0;
  //ArduinoDmx1.TxBuffer[2] = 0;
  //ArduinoDmx1.TxBuffer[3] = 0;
  //ArduinoDmx2.TxBuffer[0] = 1023;
  //ArduinoDmx2.TxBuffer[1] = 0;
  //ArduinoDmx2.TxBuffer[2] = 1023;
  //ArduinoDmx2.TxBuffer[3] = 0;
  //ArduinoDmx2.TxBuffer[4] = 0;
  //ArduinoDmx2.TxBuffer[5] = 0;
  //ArduinoDmx2.TxBuffer[6] = 0;
  //digitalWrite(FreezeLEDRed, 255);
  //digitalWrite(FreezeLEDBlue, 255);
  //Serial.println("loop 2");
  //delay(100);
  
  if (currentMillis - previousMillis >= interval) {
    // save the last time you blinked the LED
    previousMillis = currentMillis;
    digitalWrite(FreezeLEDBlue, 0);
  }
}//end loop()

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
