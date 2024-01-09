

int pin = A4;
int pin2 = A5;
void setup() {
  Serial.begin(9600);
  
  pinMode(pin, INPUT_PULLUP );   
  pinMode(pin2, INPUT_PULLUP );   
  pinMode(LED_BUILTIN, OUTPUT);

}
bool button_down = false;
bool button_down_toggle = false;

void WritePin( String pin_ , bool data ){
 
  Serial.print( pin_ + ":" + String(data) + "\n" );
  if(data){
    digitalWrite(LED_BUILTIN, HIGH);

  }else{
    digitalWrite(LED_BUILTIN, LOW);
    
  }
  
}

void loop() {
  
  button_down = !digitalRead(pin);
  button_down_toggle = !digitalRead(pin2);
 
  
  WritePin("4" , button_down);
  WritePin("5" , button_down_toggle);
 
}

 
