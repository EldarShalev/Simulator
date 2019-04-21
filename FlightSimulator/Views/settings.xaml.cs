using FlightSimulator.Model.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class Settings : StackPanel
    {

        // Creating the model instance to give to viewModel constructor during run time (DI) 
        Model.Interface.ISettingsModel settingsModel = new Model.ApplicationSettingsModel();
        
        public Settings()
        {
            InitializeComponent();
            this.DataContext = new FlightSimulator.ViewModels.Windows.SettingsWindowViewModel(settingsModel);
            
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;

        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }
    }
}
