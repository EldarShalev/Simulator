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
        IServer info;
        IServer command;
        //Windows.ConnectViewModel conModel;
   

        public FlightBoardViewModel(IServer infoServer, IServer commandServer)
        {
            this.info = infoServer;
            this.command = commandServer;
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
    }
}
