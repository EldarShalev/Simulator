using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotVM
    {
        // Members
        FlightBoardViewModel flightboard;
        TextBox textBox;
        public AutoPilotVM(FlightBoardViewModel fb, TextBox t)
        {
            this.flightboard = fb;
            this.textBox = t;
        }


        #region SendCommand
        private ICommand _sendCommand;
        public ICommand SendCommands
        {
            get
            {
                return _sendCommand ?? (_sendCommand = new CommandHandler(() => OnClick()));
            }
        }

        // When we click Ok we send list of textbox, and run each command with 2 sec delay.
        public void OnClick()
        {

            string[] delimiter = { "\r\n" };
            string theText = textBox.Text;
            List<string> result = theText.Split(delimiter, StringSplitOptions.None).ToList();
            Thread t = new Thread(delegate ()
            {
                foreach (string s in result)
                {
                    if (this.flightboard != null)
                    {
                        this.flightboard.AnyCommand = s;
                        Thread.Sleep(2000);
                    }
                }
            });
            t.Start();

            

        }
        #endregion
    }
}
