<div align="center">

![Desktop](https://img.shields.io/badge/Desktop-brown?style=for-the-badge)
![Hardware](https://img.shields.io/badge/Hardware-Arduino-00979D?style=for-the-badge&logo=arduino)
![Windows](https://img.shields.io/badge/Windows-Application-blue?style=for-the-badge)
![Network](https://img.shields.io/badge/Network-TCP/IP-green?style=for-the-badge)
![VB.NET](https://img.shields.io/badge/Language-VB.NET-red?style=for-the-badge)

*Real-time activity monitoring and visualization system*

</div>

<div align="center">
  <img src="/K-WAYD.png">
</div>

# K-WAYD

[README en Español](README_es.md)

> This project is strictly for `educational` purposes. The code must be used only in controlled environments, such as virtual machines.

`K-WAYD` (What Are You Doing) is an integrated activity monitoring system that combines hardware (Arduino with LCD display) and software (client-server apps) to visualize and log in real time what is happening on a remote computer.

The system captures information about the active window and running process, and allows basic remote control functions, showing this information both in a GUI and on an Arduino-connected LCD screen.

## 🏗️ System Architecture

`K-WAYD` is composed of three main components:

### 1. **K-WAYD (Arduino)**
Arduino-based hardware that controls a 16x2 LCD display and a navigation button.
- Receives data via serial port (9600 baud)
- Displays information in two 16-character lines
- Physical button for interaction ("Next")
- Bidirectional communication with the server

### 2. **K-WAYD (Server)**
Server application developed in Visual Basic .NET that manages connections and coordinates the system.
- Manages multiple clients simultaneously
- Communication interface with Arduino via serial port
- Activity logging
- Remote screenshot capture
- Message and notification sending
- Remote sound playback
- Control panel with GUI

### 3. **K-WAYD (Client)**
Client application that runs on monitored computers.
- Automatically captures active window and running process
- Sends info to the server via TCP/IP
- On-demand or automatic screenshot capture
- Silent background execution (system tray)
- Minimal resource usage

## ✨ Key Features

### Real-Time Monitoring
- `Activity detection`: Captures process name and active window title
- `Automatic updates`: Continuous information sent to the server
- `Multiple clients`: Supports monitoring several computers simultaneously

### Screenshot Capture
- `On demand`: Manual capture from the server
- `Automatic mode`: Configurable periodic captures
- `Auto save`: Option to store captures on disk
- `Real-time preview`: Preview in the server UI

### Remote Control
- `Pop-up messages`: Send notifications to the client
- `Sound playback`: Remote sound alert
- `Buzz`: Quick attention notification
- `Remote close`: Controlled client disconnect

### Arduino Integration
- `LCD display`: Shows info on a physical screen
- `Navigation`: Button to cycle between different clients
- `Serial port`: RS-232 communication at 9600 baud
- `Real-time updates`: Automatic synchronization

### Network Features
- `TCP/IP protocol`: Reliable client-server communication
- `Configurable port`: Default 26010
- `Auto-reconnect`: Client attempts reconnection on loss
- `Connectivity check`: Network verification before connecting

## 🔧 Requirements

### Hardware
- `Arduino UNO` (or compatible)
- `16x2 LCD display` with parallel interface
- `Push button` (switch)
- `Resistors and wires` for connections

### Software
- `Arduino IDE` 1.x or later (to program the Arduino)
- `Windows` (for server and client apps)
- `.NET Framework` (included with Windows)
- `Visual Studio` (optional, for development)

### Connectivity
- `Local network` (LAN) or direct connection
- `Serial port` available for Arduino
- `Firewall permissions` for TCP/IP communication

## 🔧 Installation

### 1. Arduino setup

#### LCD wiring
```
Arduino Pin -> LCD Pin
12 -> RS
11 -> Enable
5  -> D4
4  -> D5
3  -> D6
2  -> D7
10 -> Backlight (with resistor)
GND -> GND, VSS, RW, K
5V -> VDD, A
```

#### Button wiring
```
Pin 7 -> Switch -> GND (with internal pull-up)
```

#### Program upload
1. Open `K-WAYD (Arduino)/KWAYD.ino` in Arduino IDE
2. Verify the LiquidCrystal library is installed (included in the project)
3. Select your Arduino board and COM port
4. Upload the sketch

### 2. Server setup

1. Build the `K-WAYD (Server).sln` project in Visual Studio or run the binary
2. Run the app
3. In **Settings**:
   - Set the **network port** (default: 26010)
   - Select the **COM port** for the Arduino
   - Enable **"Use Arduino"** if hardware is connected
   - Configure Windows autostart (optional)
4. Click **"Start Server"**

### 3. Client setup

1. Build the `K-WAYD (Client).sln` project or run the binary
2. Run the app on the monitored computer
3. In **Settings**:
   - Enter the **server IP address**
   - Verify the **port** (must match the server)
   - Configure **automatic capture** (optional)
   - Adjust **capture interval** if needed
   - Enable Windows autostart (optional)
4. The app will minimize to the system tray

## 🖥️ Usage

### Server Interface

#### Main Panel
- `Client list`: Shows all connected machines
- `Activity info`: Process and active window for each client
- `Preview`: Shows the latest screenshot from the selected client
- `Activity log`: Chronological log of events

#### Toolbar
- `Switch`: Toggle server view modes
- `Capture Screen`: Request capture from the selected client
- `Send Message`: Displays a pop-up on the client
- `Play Sound`: Plays a sound on the remote machine
- `Buzz`: Sends a quick notification
- `Settings`: Server configuration

#### Context Menu
- `Save Log`: Export the activity log
- `Clear Log`: Clear the history
- `Automatic Capture`: Enable/disable periodic captures
- `Close Client`: Disconnect a specific client

### LCD Display (Arduino)

The screen shows info in two lines:
```
Line 1: Computer name or process
Line 2: Window title or status
```

Press the physical button to navigate between connected clients.

### Client Application

The client app runs in the background:
- `Tray icon`: Only visible if the active window contains the word K-WAYD in its title
- `Right click`: Access settings
- `Auto-reconnect`: Attempts to reconnect if connection is lost
- `Adaptive capture`: Only sends activity changes

## 🔒 Security Considerations

- `Local network`: Recommended for private, trusted networks only
- `No encryption`: Communication is not encrypted
- `Privacy`: The system logs all user activity

---

`Note`: This software is designed for personal and `educational` use. Use it responsibly and respect user privacy.

## 📄 License

This project is licensed under the WTFPL – [Do What the Fuck You Want to Public License](http://www.wtfpl.net/about/).

---

<div align="center">

**🖧 Developed by Kobayashi82 🖧**

*"Know what they're doing, anytime, anywhere"*

</div>

<div align="center">
  <img src="/K-WAYD%20(Arduino)/K-WAYD.jpg">
</div>
