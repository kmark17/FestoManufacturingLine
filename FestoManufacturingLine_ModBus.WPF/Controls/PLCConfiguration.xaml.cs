using CommunityToolkit.Mvvm.Input;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FestoManufacturingLine_ModBus.WPF.Controls
{
    /// <summary>
    /// Interaction logic for PLCConfiguration.xaml
    /// </summary>
    public partial class PlcConfiguration : UserControl
    {
        public static readonly DependencyProperty StationNameProperty =
           DependencyProperty.Register("StationName", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string StationName
        {
            get { return (string)GetValue(StationNameProperty); }
            set { SetValue(StationNameProperty, value); }
        }

        public static readonly DependencyProperty IsStationOnlineProperty =
           DependencyProperty.Register("IsStationOnline", typeof(bool), typeof(PlcConfiguration), new PropertyMetadata(false));

        public bool IsStationOnline
        {
            get { return (bool)GetValue(IsStationOnlineProperty); }
            set { SetValue(IsStationOnlineProperty, value); }
        }

        public static readonly DependencyProperty PlcNameProperty =
           DependencyProperty.Register("PlcName", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string PlcName
        {
            get { return (string)GetValue(PlcNameProperty); }
            set { SetValue(PlcNameProperty, value); }
        }

        public static readonly DependencyProperty TypeProperty =
           DependencyProperty.Register("Type", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly DependencyProperty IdProperty =
           DependencyProperty.Register("Id", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public static readonly DependencyProperty VersionProperty =
           DependencyProperty.Register("Version", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string Version
        {
            get { return (string)GetValue(VersionProperty); }
            set { SetValue(VersionProperty, value); }
        }

        public static readonly DependencyProperty ModelNumberProperty =
           DependencyProperty.Register("ModelNumber", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string ModelNumber
        {
            get { return (string)GetValue(ModelNumberProperty); }
            set { SetValue(ModelNumberProperty, value); }
        }

        public static readonly DependencyProperty IpAddressProperty =
           DependencyProperty.Register("IpAddress", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string IpAddress
        {
            get { return (string)GetValue(IpAddressProperty); }
            set { SetValue(IpAddressProperty, value); }
        }

        public static readonly DependencyProperty PortNumberProperty =
           DependencyProperty.Register("PortNumber", typeof(string), typeof(PlcConfiguration), new PropertyMetadata(string.Empty));

        public string PortNumber
        {
            get { return (string)GetValue(PortNumberProperty); }
            set { SetValue(PortNumberProperty, value); }
        }

        public static readonly DependencyProperty SavePlcConfigurationCommandProperty =
           DependencyProperty.Register("SavePlcConfigurationCommand", typeof(RelayCommand), typeof(PlcConfiguration), new PropertyMetadata(null));

        public RelayCommand SavePlcConfigurationCommand
        {
            get { return (RelayCommand)GetValue(SavePlcConfigurationCommandProperty); }
            set { SetValue(SavePlcConfigurationCommandProperty, value); }
        }

        public PlcConfiguration()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            plcStatusLine.Stroke = IsStationOnline ? new SolidColorBrush(Colors.DarkGreen) : new SolidColorBrush(Colors.Gray);
        }
    }
}
