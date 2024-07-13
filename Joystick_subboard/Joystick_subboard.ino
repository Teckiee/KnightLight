#include <Wire.h>
#include <ArduinoUniqueID.h>

#define Z_Pin A0
#define Y_Pin A1
#define X_Pin A2

String sUID="";

unsigned long previousMillis = 0;
const long interval = 500;
const long delaytime = 250;

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
  for (size_t i = 0; i < 3; i++)
  {
    if (UniqueID8[i] < 0x10)
      //Serial.print("0");
      sUID = sUID + "0";
    //Serial.print(UniqueID8[i], HEX); // UID:6E756E6B776F000605
    sUID = sUID + UniqueID8[i];
    //Serial.print("");
  }
  pinMode(Z_Pin, INPUT);
  pinMode(Y_Pin, INPUT);
  pinMode(X_Pin, INPUT);
  
  Wire.begin();
  
}

void loop() {
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
    /*
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= interval){
    previousMillis = currentMillis;
    
    // put your main code here, to run repeatedly:
    Serial.print("X: ");
    Serial.print(analogRead(X_Pin));
    Serial.print(" Y: ");
    Serial.print(analogRead(Y_Pin));
    Serial.print(" Z: ");
    Serial.println(analogRead(Z_Pin));   
  }
  */

  String tempX="jyX,";
  tempX.concat(analogRead(X_Pin));
  SendVal(tempX);
    
  String tempY="jyY,";
  tempY.concat(analogRead(Y_Pin));
  SendVal(tempY);
  
  String tempZ="jyZ,";
  tempZ.concat(analogRead(Z_Pin));
  SendVal(tempZ);
  delay(delaytime);
}


//black-middle
//white-right
//red-left

void SendVal(String msg){
  Serial.println(msg);
  //Wire.beginTransmission(I2C_Send_Addr);
  //Wire.write(msg.c_str());
  ////Serial.println(msg.c_str());

  //Wire.endTransmission();    // stop transmitting
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
  
    //Serial.print("Message ");
    //Serial.println(messageFromPC);
    //Serial.print("Message data ");
    //Serial.println(messageData);
}
