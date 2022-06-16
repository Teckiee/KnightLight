
#include <ArduinoUniqueID.h>

#define btnPlay 2
#define btnStop 3
#define btnPause 4
#define btnBack 5
#define btnNext 6

#define ledPlay 7
#define ledStop 8
#define ledPause 9
#define ledBack 10
#define ledNext 11

#define aVolume A0

int btnPlay_statechanged = 0;
int btnStop_statechanged = 0;
int btnPause_statechanged = 0;
int btnBack_statechanged = 0;
int btnNext_statechanged = 0;

String sUID="";

const byte numChars = 80;
char incomingBytes[80];
char tempChars[numChars];
boolean newData = false;
//int lf = 10;
char messageFromPC[numChars] = {0};
char messageData[numChars] = {0};
int integerFromPC = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
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
  pinMode(ledPlay, OUTPUT);
  pinMode(ledStop, OUTPUT);
  pinMode(ledPause, OUTPUT);
  pinMode(ledBack, OUTPUT);
  pinMode(ledNext, OUTPUT);

  pinMode(btnPlay, INPUT);
  pinMode(btnStop, INPUT);
  pinMode(btnPause, INPUT);
  pinMode(btnBack, INPUT);
  pinMode(btnNext, INPUT);
  
}

void loop() {
  // put your main code here, to run repeatedly:
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

  // Button Play
  if (btnPlay_statechanged != digitalRead(btnPlay)) {
    btnPlay_statechanged = digitalRead(btnPlay);
    digitalWrite(ledPlay, btnPlay_statechanged);
    if (btnPlay_statechanged == HIGH){
      Serial.println("MUS,Play");
      //digitalWrite(ledPlay, HIGH);
    }
  }
  // Button Stop
  if (btnStop_statechanged != digitalRead(btnStop)) {
    btnStop_statechanged = digitalRead(btnStop);
    digitalWrite(ledStop, btnStop_statechanged);
    if (btnStop_statechanged == HIGH){
      Serial.println("MUS,Stop");
      //digitalWrite(ledStop, HIGH);
    }
  }
  // Button Pause
  if (btnPause_statechanged != digitalRead(btnPause)) {
    btnPause_statechanged = digitalRead(btnPause);
    digitalWrite(ledPause, btnPause_statechanged);
    if (btnPause_statechanged == HIGH){
      Serial.println("MUS,Pause");
      //digitalWrite(ledPause, HIGH);
    }
  }
  // Button Back
  if (btnBack_statechanged != digitalRead(btnBack)) {
    btnBack_statechanged = digitalRead(btnBack);
    digitalWrite(ledBack, btnBack_statechanged);
    if (btnBack_statechanged == HIGH){
      Serial.println("MUS,Back");
      //digitalWrite(ledBack, HIGH);
    }
  }
  // Button Next
  if (btnNext_statechanged != digitalRead(btnNext)) {
    btnNext_statechanged = digitalRead(btnNext);
    digitalWrite(ledNext, btnNext_statechanged);
    if (btnNext_statechanged == HIGH){
      Serial.println("MUS,Next");
      //digitalWrite(ledNext, HIGH);
    }
  }
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
    delay(50);
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
