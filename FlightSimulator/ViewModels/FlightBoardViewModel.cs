using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using System.ComponentModel;
using FlightSimulator.ViewModels.Windows;
using System.Windows.Input;
using System.Net;

namespace FlightSimulator.ViewModels
{
    public partial class FlightBoardViewModel : BaseNotify
    {
        // Members
        IServer info;
        IServer command;
        double throttle;
        double rudder;
        bool connectedCommand;
   
        
        /**
         * Constructor with server and client
         */
        public FlightBoardViewModel(IServer infoServer, IServer commandServer)
        {
            this.info = infoServer;
            this.command = commandServer;
            connectedCommand = false;
            info.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
                
            };
        }


        #region ClickCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnClick()));
            }
        }
        public void OnClick()
        {


            // Connect as a server to the simulator in new thread
            info.connect(IPAddress.Parse(Properties.Settings.Default.FlightServerIP),
               Properties.Settings.Default.FlightInfoPort);


            // Connect as a client to the simulator
            command.connect(IPAddress.Parse(Properties.Settings.Default.FlightServerIP),
                Properties.Settings.Default.FlightCommandPort);
            // Set connection as true
            connectedCommand = true;
            

        }
        #endregion


        public double Lon
        {
            get { return ((InfoServer)info).Longitude; } 
            
        }

        public double Lat
        {
            get { return ((InfoServer)info).Latitude; }
        }


        // Setting throttle
        public double Throttle
        {
            set
            {
                throttle = value;
                string parsedThrottle = throttle.ToString();
                command.write("set /controls/engines/current-engine/throttle " + parsedThrottle 
                    +"\r\n");
            }
        }

        // Setting Rudder
        public double Rudder
        {
            set
            {
                rudder = value;
                string parsedRudder = rudder.ToString();
                command.write("set /controls/flight/rudder " + parsedRudder + "\r\n");
            }
        }

        // For any command with autopilot TextBox
        public string AnyCommand
        {
            set
            {
                command.write(value+ "\r\n");
            }
        }

        // Setting Elevator
        double elevator;
        public double Elevator
        {
            set
            {
                elevator = value;
                string parsedElevator = elevator.ToString();
                if (connectedCommand)
                    command.write("set /controls/flight/elevator " + parsedElevator + "\r\n");
            }
        }

        // Settin aileron
        double aileron;
        public double Aileron
        {
            set
            {
                aileron = value;
                string parsedAileron = aileron.ToString();
                if (connectedCommand)
                    command.write("set /controls/flight/aileron " + parsedAileron + "\r\n");
            }
        }








    }
}
