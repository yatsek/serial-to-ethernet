| **Arduino pin number** | **Connect to...** | **Notes** |
|:-----------------------|:------------------|:----------|
|10                      |EtherShield SPI SS |           |
|11                      |EtherShield SPI MOSI|           |
|12                      |EtherShield SPI MISO|           |
|13                      |EtherShield SPI SCK|           |
|0                       |Remote serial port RX|           |
|1                       |Remote serial port TX |           |
|2                       |Blue led           |Network activity|
|3                       |Green led          |Port status|
|4                       |Red led            |Output buffer overflow|
|5                       |Yellow led         |Got something to output|

  * Do not forget to connect power and ground wires also.
  * You can take 3.3v to power EtherShield board from Arduino with the risk of burn out ft232 chip. The better way is use voltage regulator such as lm1117-3.3.
  * EtherShield board data pins tolerated to Arduino 5v signal levels.