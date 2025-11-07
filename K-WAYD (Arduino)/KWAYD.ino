
#include <LiquidCrystal.h>
LiquidCrystal lcd (12, 11, 5, 4, 3, 2);

const int lcdPin = 10;
const int switchPin = 7;
int switchState = 0;
int prevSwitchState = 0;

void setup() {
  Serial.begin(9600);
  lcd.begin(16, 2);
  pinMode(switchPin, INPUT);
  pinMode(lcdPin, OUTPUT);
  analogWrite(lcdPin, 5);
  lcd.print("   K-WAYD 1.0");
  lcd.setCursor(0, 1);
}

void loop() {
  if (Serial.available() > 0 ) { receive_data(); }
  switchState = debounce(prevSwitchState);

  if (prevSwitchState == LOW && switchState == HIGH) { Serial.println("Next[E]"); }
  prevSwitchState = switchState;
}

boolean debounce (boolean last) {
  boolean current = digitalRead(switchPin);
  if (last != current) {
    delay(5);
    current = digitalRead(switchPin);
  }
  return current;
}

void receive_data() {
  String receivedString = Serial.readStringUntil('\n');  
  
  int delimiterIndex = receivedString.indexOf('||');
  if (delimiterIndex != -1) {
    String mensaje1 = receivedString.substring(0, delimiterIndex);
    String mensaje2 = receivedString.substring(delimiterIndex + 2);
    quitarCrLf(mensaje2);
    //lcd.clear();
    while (mensaje1.length() < 16) { mensaje1 += ' '; }
    while (mensaje2.length() < 16) { mensaje2 += ' '; }
    lcd.setCursor(0, 0);
    lcd.print(mensaje1);
    lcd.setCursor(0, 1);
    lcd.print(mensaje2);
  }
}

void quitarCrLf(String &cadena) {
  int longitud = cadena.length();

  while (longitud > 0 && (cadena[longitud - 1] == '\r' || cadena[longitud - 1] == '\n')) {
    cadena.remove(longitud - 1);
    longitud = cadena.length();
  }
}


