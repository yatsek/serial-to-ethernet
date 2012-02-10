#include <dhcp.h>
#include <dnslkup.h>
#include <enc28j60.h>
#include <EtherShield.h>
#include <ip_arp_udp_tcp.h>
#include <ip_config.h>
#include <net.h>
#include <websrv_help_functions.h>


#include <EEPROM.h>
#include <avr/wdt.h>



uint8_t _mac[6] = {0x54,0x55,0x58,0x10,0x00,0x25}; 

uint8_t _ip[4] = {192,168,0,133};


#define PORT 80
#define BUFFER_SIZE 550



#define PIN_BLUE    2
#define PIN_GREEN   3
#define PIN_RED     4
#define PIN_YELLOW  5 
#define SETTINGSADDR     0
#define NOSETTINGS       0xFF

struct SETTINGS
{
  byte Flag;
  long Baud;
};


SETTINGS _settings;
uint8_t _buf[BUFFER_SIZE];
char _sbuf[BUFFER_SIZE+1];
int _sbufsize=0;
boolean _sbufoverflow=false;
boolean _uartstarted=false;


EtherShield _es=EtherShield();



#define ANIMATIONSPEED 200
void StartupAnimation(int value)
{
  digitalWrite(PIN_BLUE, value);
  delay(ANIMATIONSPEED);
  digitalWrite(PIN_GREEN, value);
  delay(ANIMATIONSPEED);
  digitalWrite(PIN_RED, value);
  delay(ANIMATIONSPEED);
  digitalWrite(PIN_YELLOW, value);
  delay(ANIMATIONSPEED);
  

}

void setup()
{
  pinMode(PIN_BLUE,  OUTPUT); 
  pinMode(PIN_GREEN, OUTPUT);
  pinMode(PIN_RED,   OUTPUT);
  pinMode(PIN_YELLOW,  OUTPUT);


  StartupAnimation(HIGH);


  _es.ES_enc28j60SpiInit();
  _es.ES_enc28j60Init(_mac);
  

  
  _es.ES_init_ip_arp_udp_tcp(_mac,_ip, PORT);
  
  StartupAnimation(LOW);    

  SettingsRead(SETTINGSADDR,&_settings,sizeof(SETTINGS));
  if (_settings.Flag == NOSETTINGS)
  {
        _settings.Flag =0;
        _settings.Baud =0;
        SettingsWrite(SETTINGSADDR,&_settings,sizeof(SETTINGS));
  } else
  {
      if (_settings.Baud !=0)
      {
         Serial.begin(_settings.Baud);
         _uartstarted=true;
         digitalWrite(PIN_GREEN, HIGH);
      }
  }
  
  
  wdt_enable(WDTO_8S);
}


long _t=0;

void CheckBuffer()
{
  static char ch;
  
  if (!_uartstarted) return;
  
  while (Serial.available() > 0) 
  {
      ch = Serial.read();
      if (ch==0) continue;
      if (!_sbufoverflow) 
      {    _sbuf[_sbufsize++]=ch;
          analogWrite(PIN_YELLOW, 100);
      }
      if (_sbufsize>=BUFFER_SIZE) 
      {   _sbuf[BUFFER_SIZE]=0; 
          _sbufoverflow =true;
          digitalWrite(PIN_RED, HIGH);
          break;
      }
  }
  if (!_sbufoverflow) _sbuf[_sbufsize]=0;

}

void ClearBuffer()
{
  memset(_sbuf,0,BUFFER_SIZE+1);
  _sbufsize=0;
  _sbufoverflow =false;
  digitalWrite(PIN_YELLOW, LOW);
  digitalWrite(PIN_RED, LOW);
  
}


void ProcessCmd(uint16_t  dat_p)
{
  long i;
  
  
  if (strncmp("HELP",(char *)&(_buf[dat_p]),4)==0)
  {
    sprintf(_sbuf,"\r\n--- UART2ETH\r\nSTART <baud>\r\nSTOP\r\nGET\r\nPUT <data>\r\nCLEAR\r\nHELP\r\n");
    return;
  } 
  
  if (strncmp("GET",(char *)&(_buf[dat_p]),3)==0)
  {
    return;
  }

  if (strncmp("PUT",(char *)&(_buf[dat_p]),3)==0)
  {
    if (!_uartstarted)
    {  sprintf(_sbuf,"\r\n--- Send START first\r\n");
    } else
    {  sprintf(_sbuf,"\r\n--- ");
       
       i=0;
       while(_buf[i+4+dat_p]!=0)
       {  Serial.write(_buf[i+4+dat_p]); 
          _sbuf[i+6] = _buf[i+4+dat_p];
          i++;
       }
       i++;
       _sbuf[i+6] = 0;
       
    }
    return;
  }
 
  
  if (strncmp("START ",(char *)&(_buf[dat_p]),6)==0)
  {
    i=0;
    sscanf ((char *)&(_buf[dat_p+6]),"%ld",&i);
    Serial.begin(i);
    sprintf(_sbuf,"\r\n--- Started %ld\r\n",i);
    _uartstarted=true;
    digitalWrite(PIN_GREEN, HIGH);
    _settings.Baud =i;
    SettingsWrite(SETTINGSADDR,&_settings,sizeof(SETTINGS));    
    return;
  }
  
  if (strncmp("STOP",(char *)&(_buf[dat_p]),4)==0)
  {
     _uartstarted=false;
     ClearBuffer();
     Serial.end() ;
     sprintf(_sbuf,"\r\n--- Stopped\r\n");
     digitalWrite(PIN_GREEN, LOW);
     _settings.Baud =0;
     SettingsWrite(SETTINGSADDR,&_settings,sizeof(SETTINGS));        
     return;
  }
  
  if (strncmp("CLEAR",(char *)&(_buf[dat_p]),5)==0)
  {
     sprintf(_sbuf,"\r\n--- Cleared\r\n");
     return;
  }

  sprintf(_sbuf,"\r\n--- Unknown command\r\n");
  
}


void loop()
{
  uint16_t  dat_p;
  
  wdt_reset();  

  digitalWrite(PIN_BLUE, LOW);
  CheckBuffer();
  dat_p=_es.ES_packetloop_icmp_tcp(_buf,_es.ES_enc28j60PacketReceive(BUFFER_SIZE,_buf));

  if(dat_p==0)  return;
  digitalWrite(PIN_BLUE, HIGH);  
 
  ProcessCmd(dat_p);
    
  dat_p=_es.ES_fill_tcp_data(_buf,0,_sbuf);
  ClearBuffer();
  _es.ES_www_server_reply(_buf,dat_p); 

}

void SettingsRead(int eepromaddr,void* addr,int len)
{
    for(int i=0;i<len;i++)
      *(((byte*)addr)+i) = EEPROM.read(i+eepromaddr);
}


void SettingsWrite(int eepromaddr,void* addr,int len)
{
    for(int i=0;i<len;i++)
      EEPROM.write(i+eepromaddr,*(((byte*)addr)+i));
}
