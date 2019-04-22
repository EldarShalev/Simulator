using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;

namespace FlightSimulator.Model
{
    class CommandServer : IServer
    {
        // The command client
        public event PropertyChangedEventHandler PropertyChanged;
        NetworkStream netStream;
        public CommandServer() {   }
        
        // The connect 
        public void connect(IPAddress ip, int port)
        {
            // By default the client try to connect to given ip and port
            TcpClient client = new TcpClient(ip.ToString(), port);
            netStream = client.GetStream();
            
        }

        // Optinal, no oblligation to implement
        public void disconnect()
        {
            
        }

        // No need to read for now, only sending commands to simulator
        public string read()
        {
            return "Nothing";
        }

        // This function send commands as strings
        public void write(string line)
        {
            netStream.Flush();
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(line);
            netStream.Write(data, 0, data.Length);

        }

        // To notify if something changed
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
