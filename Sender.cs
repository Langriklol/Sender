using System;
using System.IO.Ports;

namespace Sender{
    //Honestly, you do not need this class... System.IO.Ports is working only under Windows... 
    public class Sender{

        private SerialPort _serialPort;

        /// <param name="device">Name of device - p.g. /dev/ttyUSB0 </param>
        public Sender(string device, int baudRate){
            this._serialPort = new SerialPort(device)
            {
                BaudRate = baudRate,
                Parity = Parity.None,
                StopBits = StopBits.One,
                DataBits = 8,
                Handshake = Handshake.None
            };
        }

        /// <param name="note">Note itself</param>
        public void Send(Note note)
        {
            this._serialPort.WriteLine(
                String.Format(
                    "{0},{1},{2}",
                    note.getName(),
                    note.getFrequency(), 
                    note.getDuration()
                )
            );
        }
    }
}