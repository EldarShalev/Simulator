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

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Members
        Model.Interface.ISettingsModel settingsModel = new Model.ApplicationSettingsModel();
        FlightSimulator.ViewModels.Windows.SettingsWindowViewModel settingViewModelObject;
        Views.Settings settings = new Views.Settings();


        public MainWindow()
        {
            InitializeComponent();
            settingViewModelObject = 
                new FlightSimulator.ViewModels.Windows.SettingsWindowViewModel(settingsModel);

        }

        private void FlightBoard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Joystick_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SettingButton(object sender, RoutedEventArgs e)
        {
            Model.Interface.ISettingsModel settingsModel = new Model.ApplicationSettingsModel();
            FlightSimulator.ViewModels.Windows.SettingsWindowViewModel settingViewModelObject =
               new FlightSimulator.ViewModels.Windows.SettingsWindowViewModel(settingsModel);
            //settingViewModelObject.ReloadSettings();
            //SettingControl.DataContext = settingViewModelObject;

        }

        private void ConnectButton(object sender, RoutedEventArgs e)
        {
            
        }
        private void SettingControl_Loaded(object sender, RoutedEventArgs e)
        {
            SettingControl.DataContext = settingViewModelObject;
        }


    }
}
