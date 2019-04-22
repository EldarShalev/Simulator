using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using FlightSimulator.Model.EventArgs;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    class InfoServer  : IServer
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Members
        float m_longitude;
        float m_latitude;
        volatile Boolean stop;
        int counter1 = 0;


        // Ctor
        public InfoServer() {
            stop = false;
        }

        public float Longitude
        {
            get { return m_longitude; }
            set
            {
                m_longitude = value;
                NotifyPropertyChanged("Lon");
            }
        }

        public float Latitude
        {
            get { return m_latitude; }
            set
            {
                m_latitude = value;
                NotifyPropertyChanged("Lat");
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        public void connect(IPAddress ip, int port)
        {
            // Establish the local endpoint  
            // for the socket. Dns.GetHostName 
            // returns the name of the host  
            // running the application. 
            IPEndPoint localEndPoint = new IPEndPoint(ip, port);

            // Creation TCP/IP Socket using  
            // Socket Class Costructor 
            Socket listener = new Socket(ip.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);


            try
            {

                // Using Bind() method we associate a 
                // network address to the Server Socket 
                // All client that will connect to this  
                // Server Socket must know this network 
                // Address 
                listener.Bind(localEndPoint);

                // Using Listen() method we create  
                // the Client list that will want 
                // to connect to Server 
                listener.Listen(10);

                // listen always on new thread
                Thread t1 = new Thread(delegate ()
                {
                    Console.WriteLine("Waiting connection ... ");
                    // Suspend while waiting for 
                    // incoming connection Using  
                    // Accept() method the server  
                    // will accept connection of client 
                    Socket clientSocket = listener.Accept();
                    while (!stop)
                    {
                        // Data buffer 
                        byte[] bytes = new Byte[1024];
                        string data = null;

                        int numByte = clientSocket.Receive(bytes);
                        data = ASCIIEncoding.ASCII.GetString(bytes,0, numByte);
                        ParseTheData(data);
                        //Thread.Sleep(250);
                    }
                });
                t1.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ParseTheData(string readData)
        {

            /** This is all the possibilities to read and parse the bytes read from the server
             *  including edge cases for reading not sequentially (too much bytes)
             *  This is to parse the Lon and the Lat parameters which are the first and second
             *  to be read.
             * **/
            char delimiter = ',';
            int counter = 0;
            int counter2 = 0;
            string longitudeOpt1 = "";
            string longitudeOpt2 = "0";
            string latitudeOpt1 = "";
            string latitudeOpt2 = "0";
            string temp = "";
            string temp2 = "";
            bool flg = false;
            foreach (Char c in readData)
            {
                if (c == '\n')
                {
                    flg = true;
                    continue;
                }
                else
                {
                    if (flg == false)
                    {
                        if (c != delimiter)
                            temp2 += c;
                        else
                        {
                            if (counter2 == 0)
                            {
                                longitudeOpt2 = temp2;
                                temp2 = "";
                                counter2++;
                            }
                            else if (counter2==1)
                            {
                                latitudeOpt2 = temp2;
                                counter2++;
                            } else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (c != delimiter)
                            temp += c;
                        else
                        {
                            if (counter == 0)
                            {
                                longitudeOpt1 = temp;
                                temp = "";
                                counter++;
                            }
                            else
                            {
                                latitudeOpt1 = temp;
                                break;
                            }
                        }
                    }
                }    
            }

            // Edge cases
            if (longitudeOpt1 == "")
                longitudeOpt1 = longitudeOpt2;
            if (latitudeOpt1 == "")
                latitudeOpt1 = latitudeOpt2;

            // Changing the objects will call to set property 
            Longitude = float.Parse(longitudeOpt1);
            Latitude = float.Parse(latitudeOpt1);              
        }

        // Not mandatory to implement.
        public void disconnect()
        {
            stop = true;
        }

        // No need to read from server for now, only lon and lat that call set property.
        public string read()
        {
            throw new NotImplementedException();
        }

        // No need to write to server, only get info from it.
        public void write(string line)
        {
            throw new NotImplementedException();
        }


    }
}
