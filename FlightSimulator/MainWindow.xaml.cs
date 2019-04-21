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

        FlightBoardViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            

        }


        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SettingButton(object sender, RoutedEventArgs e)
        {

            SettingControl.Visibility = Visibility.Visible;

        }

        private void ConnectButton(object sender, RoutedEventArgs e)
        {
            viewModel = new FlightBoardViewModel(new InfoServer(), new CommandServer());
            DataContext = viewModel;
            //FlightBoard_Loaded_1(sender, e);
            this.FlBoard.DataContext = viewModel;
            viewModel.PropertyChanged += this.FlBoard.Vm_PropertyChanged;
        }

        private void settingButton_Checked(object sender, RoutedEventArgs e)
        {
            SettingControl.Visibility = Visibility.Visible;

        }

        private void ClearButton(object sender, RoutedEventArgs e)
        {
            ClearTextBox.Clear();
        }

    }
}
