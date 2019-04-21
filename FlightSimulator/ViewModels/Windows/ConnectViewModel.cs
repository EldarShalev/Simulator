using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Input;
using System.ComponentModel;

namespace FlightSimulator.ViewModels.Windows
{
    public class ConnectViewModel : BaseNotify
    {
        // Create here 2 servers and connect them
        IServer client; 
        public IServer info;

        public ConnectViewModel() { }
        public ConnectViewModel(IServer info1)
        {
            // Creating two new servers
            client = new CommandServer();
            info = info1;

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

            //FlightBoardViewModel flightBoard = new FlightBoardViewModel(info);
            
            // Connect as a client to the simulator
            client.connect(IPAddress.Parse(Properties.Settings.Default.FlightServerIP),
                Properties.Settings.Default.FlightCommandPort);

        }
        #endregion

    }
}
