using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Solid.Arduino;
using Solid.Arduino.Firmata;

namespace ClassLibrary1
{

    public class ArduinoFirmata
    {
        private static ISerialConnection serialConnectionPort;

        public static void AutoOpenTest()
        {
            for (int x = 0; x < 1; x++)
            {
                serialConnectionPort = SerialConnection.FindSerialConnection();
            }
        }

        public static void Blinky()
        {
            var connection = new EnhancedSerialConnection(serialConnectionPort.PortName, SerialBaudRate.Bps_57600);
            var session = new ArduinoSession(connection, timeOut: 250);
            IFirmataProtocol firmata = session;
            firmata.SetDigitalPinMode(13, PinMode.DigitalOutput);

            while (true)
            {
                firmata.SetDigitalPort(1, 0xff);
                Thread.Sleep(1000);
                firmata.SetDigitalPort(1, 0x00);
                Thread.Sleep(1000);
            }
        }
    }
}
