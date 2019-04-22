using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using FlightSimulator.ViewModels;
using FlightSimulator.Model;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Member
        FlightBoardViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void SettingButton(object sender, RoutedEventArgs e)
        {

            SettingControl.Visibility = Visibility.Visible;

        }

        /** The connect button set the data context of our crtical elements to be the new view
         model the was created. (Data context also can be in xaml but here is much more clear
          what are the crucial elements).
        */
        private void ConnectButton(object sender, RoutedEventArgs e)
        {
            viewModel = new FlightBoardViewModel(new InfoServer(), new CommandServer());
            DataContext = viewModel;
            this.FlBoard.DataContext = viewModel;
            this.throttleSlider.DataContext = viewModel;
            this.rudderSlider.DataContext = viewModel;
            this.JoyStickView.DataContext = viewModel;
            viewModel.PropertyChanged += this.FlBoard.Vm_PropertyChanged;
        }

        private void settingButton_Checked(object sender, RoutedEventArgs e)
        {
            SettingControl.Visibility = Visibility.Visible;

        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            TextBoxCommands.Clear();
            this.TextBoxCommands.Background = new SolidColorBrush(Colors.White);
        }


        private void ClearTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.TextBoxCommands.Background = new SolidColorBrush(Colors.LightPink);
        }

        // Binding VM for autopilot
        private void OKSendCommand(object sender, RoutedEventArgs e)
        {    
            this.OKCommands.DataContext = new AutoPilotVM(viewModel, this.TextBoxCommands);
            this.TextBoxCommands.Background = new SolidColorBrush(Colors.White);

        }
    }
}
