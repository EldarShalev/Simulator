using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace FlightSimulator.Model
{
    class CommandServer : IServer
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public CommandServer() { 


        }
        public void connect(IPAddress ip, int port)
        {
            IPEndPoint localEndPoint = new IPEndPoint(ip, port);
            Socket sender = new Socket(ip.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
            try
            {

                // Connect Socket to the remote  
                // endpoint using method Connect() 
                sender.Connect(localEndPoint);

                // We print EndPoint information  
                // that we are connected 
                Console.WriteLine("Socket connected to -> {0} ",
                              sender.RemoteEndPoint.ToString());

                // Creation of messagge that 
                // we will send to Server 
                byte[] messageSent = Encoding.ASCII.GetBytes("Test Client<EOF>");
                int byteSent = sender.Send(messageSent);

                // Data buffer 
                byte[] messageReceived = new byte[1024];


                // Reading part:

                // We receive the messagge using  
                // the method Receive(). This  
                // method returns number of bytes 
                // received, that we'll use to  
                // convert them to string 
                /*
                
                
                int byteRecv = sender.Receive(messageReceived);
                Console.WriteLine("Message from Server -> {0}",
                      Encoding.ASCII.GetString(messageReceived,
                                                 0, byteRecv));

                // Close Socket using  
                // the method Close() 
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                */

            }

            // Manage of Socket's Exceptions 
            catch (ArgumentNullException ane)
            {

                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }

            catch (SocketException se)
            {

                Console.WriteLine("SocketException : {0}", se.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }


        }

        public void disconnect()
        {
            
        }

        public string read()
        {
            return "Nothing";
        }

        public void write(string line)
        {
            
        }


        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            //this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
