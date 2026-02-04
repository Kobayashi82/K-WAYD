
<div align="center">

![Desktop](https://img.shields.io/badge/Desktop-brown?style=for-the-badge)
![Hardware](https://img.shields.io/badge/Hardware-Arduino-00979D?style=for-the-badge&logo=arduino)
![Windows](https://img.shields.io/badge/Windows-Application-blue?style=for-the-badge)
![Network](https://img.shields.io/badge/Network-TCP/IP-green?style=for-the-badge)
![VB.NET](https://img.shields.io/badge/Language-VB.NET-red?style=for-the-badge)

*Sistema de monitoreo y visualización de actividad en tiempo real*

</div>

<div align="center">
  <img src="/K-WAYD.png">
</div>

# K-WAYD

[README in English](README.md)

> Este proyecto es únicamente para fines `educativos`. El código debe usarse solo en entornos controlados, como máquinas virtuales.

`K-WAYD` (What Are You Doing) es un sistema integrado de monitoreo de actividad que combina hardware (Arduino con pantalla LCD) y software (aplicaciones cliente-servidor) para visualizar y registrar en tiempo real lo que está sucediendo en una computadora remota.

El sistema captura información sobre la ventana activa, el proceso en ejecución y permite el control remoto de funciones básicas, mostrando esta información tanto en una interfaz gráfica como en una pantalla LCD conectada a un Arduino.

## 🏗️ Arquitectura del Sistema

`K-WAYD` está compuesto por tres componentes principales:

### 1. **K-WAYD (Arduino)** 
Hardware basado en Arduino que controla una pantalla LCD 16x2 y un botón de navegación.
- Recibe datos vía puerto serial (9600 baudios)
- Muestra información en dos líneas de 16 caracteres
- Botón físico para interacción ("Next")
- Comunicación bidireccional con el servidor

### 2. **K-WAYD (Server)**
Aplicación servidor desarrollada en Visual Basic .NET que gestiona las conexiones y coordina el sistema.
- Gestiona múltiples clientes simultáneos
- Interfaz de comunicación con Arduino vía puerto serial
- Registro de actividad (logging)
- Captura de pantalla remota
- Envío de mensajes y notificaciones
- Reproducción de sonidos remotos
- Panel de control con interfaz gráfica

### 3. **K-WAYD (Client)**
Aplicación cliente que se ejecuta en las computadoras monitoreadas.
- Captura automática de ventana activa y proceso en ejecución
- Envío de información al servidor vía TCP/IP
- Captura de pantalla bajo demanda o automática
- Ejecución silenciosa en segundo plano (system tray)
- Mínimo uso de recursos

## ✨ Características Principales

### Monitoreo en Tiempo Real
- `Detección de actividad`: Captura el nombre del proceso y título de la ventana activa
- `Actualización automática`: Envío continuo de información al servidor
- `Múltiples clientes`: Soporte para monitorear varias computadoras simultáneamente

### Captura de Pantalla
- `Bajo demanda`: Captura manual desde el servidor
- `Modo automático`: Capturas periódicas configurables
- `Guardado automático`: Opción para almacenar capturas en disco
- `Visualización en tiempo real`: Preview en la interfaz del servidor

### Control Remoto
- `Mensajes emergentes`: Envío de notificaciones al cliente
- `Reproducción de sonidos`: Alerta sonora remota
- `Buzz`: Notificación rápida de atención
- `Cierre remoto`: Desconexión controlada del cliente

### Integración con Arduino
- `Visualización LCD`: Muestra información en pantalla física
- `Navegación`: Botón para alternar entre diferentes clientes
- `Puerto serial`: Comunicación RS-232 a 9600 baudios
- `Actualización en tiempo real`: Sincronización automática

### Características de Red
- `Protocolo TCP/IP`: Comunicación confiable cliente-servidor
- `Puerto configurable`: Por defecto 26010
- `Reconexión automática`: El cliente intenta reconectarse si pierde conexión
- `Detección de conectividad`: Verificación de red antes de intentar conexión

## 🔧 Requisitos

### Hardware
- `Arduino UNO` (o compatible)
- `Pantalla LCD 16x2` con interfaz paralela
- `Pulsador` (switch)
- `Resistencias y cables` para conexiones

### Software
- `Arduino IDE` 1.x o superior (para programar el Arduino)
- `Windows` (para las aplicaciones servidor y cliente)
- `.NET Framework` (incluido en Windows)
- `Visual Studio` (opcional, solo para desarrollo)

### Conectividad
- `Red local` (LAN) o conexión directa
- `Puerto serial` disponible para Arduino
- `Permisos de firewall` para comunicación TCP/IP

## 📋 Instalación

### 1. Configuración del Arduino

#### Conexiones del LCD
```
Arduino Pin -> LCD Pin
12 -> RS
11 -> Enable
5  -> D4
4  -> D5
3  -> D6
2  -> D7
10 -> Backlight (con resistencia)
GND -> GND, VSS, RW, K
5V -> VDD, A
```

#### Conexión del Botón
```
Pin 7 -> Switch -> GND (con pull-up interno)
```

#### Carga del Programa
1. Abre `K-WAYD (Arduino)/KWAYD.ino` en Arduino IDE
2. Verifica que la librería LiquidCrystal esté instalada (incluida en el proyecto)
3. Selecciona tu placa Arduino y puerto COM
4. Carga el sketch

### 2. Configuración del Servidor

1. Compila el proyecto `K-WAYD (Server).sln` en Visual Studio o ejecuta el binario
2. Ejecuta la aplicación
3. En **Settings**:
   - Configura el **puerto de red** (por defecto: 26010)
   - Selecciona el **puerto COM** del Arduino
   - Activa la opción **"Usar Arduino"** si tienes el hardware conectado
   - Configura el inicio automático con Windows (opcional)
4. Presiona **"Iniciar Servidor"**

### 3. Configuración del Cliente

1. Compila el proyecto `K-WAYD (Client).sln` o ejecuta el binario
2. Ejecuta la aplicación en la computadora a monitorear
3. En **Settings**:
   - Ingresa la **dirección IP del servidor**
   - Verifica el **puerto** (debe coincidir con el servidor)
   - Configura la **captura automática** (opcional)
   - Ajusta el **intervalo de captura** si es necesario
   - Activa el inicio automático con Windows (opcional)
4. La aplicación se minimizará a la bandeja del sistema

## 🎮 Uso

### Interfaz del Servidor

#### Panel Principal
- `Lista de clientes`: Muestra todos los equipos conectados
- `Información de actividad`: Proceso y ventana activa de cada cliente
- `Vista previa`: Muestra la última captura de pantalla del cliente seleccionado
- `Registro de actividad`: Log cronológico de eventos

#### Barra de Herramientas
- `Switch`: Alterna entre modos de visualización en el servidor
- `Capturar Pantalla`: Solicita captura del cliente seleccionado
- `Enviar Mensaje`: Muestra un mensaje emergente en el cliente
- `Play Sound`: Reproduce un sonido en el equipo remoto
- `Buzz`: Envía notificación rápida
- `Settings`: Configuración del servidor

#### Menú Contextual
- `Guardar Log`: Exporta el registro de actividad
- `Vaciar Log`: Limpia el historial
- `Captura Automática`: Activa/desactiva capturas periódicas
- `Cerrar Cliente`: Desconecta un cliente específico

### Display LCD (Arduino)

La pantalla muestra información en dos líneas:
```
Línea 1: Nombre del equipo o proceso
Línea 2: Título de ventana o estado
```

Presiona el botón físico para navegar entre diferentes clientes conectados.

### Aplicación Cliente

La aplicación cliente funciona en segundo plano:
- `Ícono en bandeja`: Solo visible si la ventana activa contiene la palabra K-WAYD en su titulo
- `Click derecho`: Acceso a configuración
- `Reconexión automática`: Intenta reconectarse si pierde conexión
- `Captura adaptativa`: Solo envía cambios de actividad

## 🔒 Consideraciones de Seguridad

- `Red local`: Se recomienda usar solo en redes privadas y confiables
- `Sin cifrado`: La comunicación no está cifrada
- `Privacidad`: El sistema registra toda la actividad del usuario

---

`Nota`: Este software está diseñado para uso personal y `educativo`. Úsalo de manera responsable y respetando la privacidad de los usuarios.

## 📄 Licencia

Este proyecto está licenciado bajo la WTFPL – [Do What the Fuck You Want to Public License](http://www.wtfpl.net/about/).

---

<div align="center">

**🖧 Desarrollado por Kobayashi82 🖧**

*"Know what they're doing, anytime, anywhere"*

</div>

<div align="center">
  <img src="/K-WAYD%20(Arduino)/K-WAYD.jpg">
</div>
