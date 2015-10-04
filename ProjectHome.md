# General connection diagram #

![http://serial-to-ethernet.googlecode.com/svn/wiki/globalscheme.png](http://serial-to-ethernet.googlecode.com/svn/wiki/globalscheme.png)

# Hardware #

  * ENC28J60 EtherShield board
  * [Arduino](http://www.arduino.cc/) board based on ATMEGA328 chip
  * [Connection chart](http://code.google.com/p/serial-to-ethernet/wiki/ConnectionChart)



# Firmware #

  * EtherShield Arduino library
  * Arduino script



# Host side software #

  * [Arduino 1.0 IDE](http://arduino.googlecode.com/files/arduino-1.0-windows.zip)
  * [Client application](http://code.google.com/p/serial-to-ethernet/wiki/ClientApplication) (Visual Studio 2008 project)




### Notes: ###
  * Device input buffer is too small to work with serial port on full load.
  * Device IP 192.168.0.133 hardcoded in the Arduino script and Client application.