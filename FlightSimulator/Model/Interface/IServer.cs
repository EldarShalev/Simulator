using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace FlightSimulator.Model.Interface
{
    public interface IServer : INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;

        void connect(IPAddress ip, int port);
        void disconnect();
        string read();
        void write(string line);




        void NotifyPropertyChanged(string propName);
    }
}
