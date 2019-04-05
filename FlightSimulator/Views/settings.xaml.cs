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
    public partial class Settings : StackPanel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _IP_Text;

        Model.Interface.ISettingsModel settingsModel = new Model.ApplicationSettingsModel();
        //FlightSimulator.ViewModels.Windows.SettingsWindowViewModel settingViewModelObject;
        public Settings()
        {
            InitializeComponent();
            //settingViewModelObject =
            //    new FlightSimulator.ViewModels.Windows.SettingsWindowViewModel(settingsModel);
            //settingViewModelObject.ReloadSettings();
            //this.DataContext = settingViewModelObject;
            //this.IPText = this.settingsModel.FlightServerIP;
            //this.IPText = "hello";
            this.DataContext = new FlightSimulator.ViewModels.Windows.SettingsWindowViewModel(settingsModel);
            


        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string IPText
        {
            get { return _IP_Text; }
            set
            {
                if (value != _IP_Text)
                {
                    _IP_Text = value;
                    OnPropertyChanged("IPText");
                }
            }
        }
        private void OKButton(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
           
        }

        private void ServerIPTextBox(object sender, TextChangedEventArgs e)
        {
        }

        private void FlightCommandPortTextBox(object sender, TextChangedEventArgs e)
        {

        }

        private void FlightInfoPortTextBox(object sender, TextChangedEventArgs e)
        {

        }

        public void LoadALL()
        {

        }
    }
}
