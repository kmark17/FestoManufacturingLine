using CommunityToolkit.Mvvm.Input;
using FestoManufacturingLine_ModBus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for PlcDetails.xaml
    /// </summary>
    public partial class PlcDetails : UserControl
    {
        public static readonly DependencyProperty IsStationOnlineProperty =
            DependencyProperty.Register("IsStationOnline", typeof(bool), typeof(PlcDetails), new PropertyMetadata(false));

        public bool IsStationOnline
        {
            get { return (bool)GetValue(IsStationOnlineProperty); }
            set { SetValue(IsStationOnlineProperty, value); }
        }

        public static readonly DependencyProperty IsListeningProperty =
            DependencyProperty.Register("IsListening", typeof(bool), typeof(PlcDetails), new PropertyMetadata(false));

        public bool IsListening
        {
            get { return (bool)GetValue(IsListeningProperty); }
            set { SetValue(IsListeningProperty, value); }
        }

        public static readonly DependencyProperty StationNameProperty =
            DependencyProperty.Register("StationName", typeof(string), typeof(PlcDetails), new PropertyMetadata(string.Empty));

        public string StationName
        {
            get { return (string)GetValue(StationNameProperty); }
            set { SetValue(StationNameProperty, value); }
        }

        public static readonly DependencyProperty StationDescriptionProperty =
            DependencyProperty.Register("StationDescription", typeof(string), typeof(PlcDetails), new PropertyMetadata(string.Empty));

        public string StationDescription
        {
            get { return (string)GetValue(StationDescriptionProperty); }
            set { SetValue(StationDescriptionProperty, value); }
        }

        public static readonly DependencyProperty StationNumberOfInputsOutputsProperty =
            DependencyProperty.Register("StationNumberOfInputsOutputs", typeof(string), typeof(PlcDetails), new PropertyMetadata(string.Empty));

        public string StationNumberOfInputsOutputs
        {
            get { return (string)GetValue(StationNumberOfInputsOutputsProperty); }
            set { SetValue(StationNumberOfInputsOutputsProperty, value); }
        }

        public static readonly DependencyProperty StationReqPowerAirPressureProperty =
            DependencyProperty.Register("StationReqPowerAirPressure", typeof(string), typeof(PlcDetails), new PropertyMetadata(string.Empty));

        public string StationReqPowerAirPressure
        {
            get { return (string)GetValue(StationReqPowerAirPressureProperty); }
            set { SetValue(StationReqPowerAirPressureProperty, value); }
        }

        public static readonly DependencyProperty StationModBusInputVariablesProperty =
            DependencyProperty.Register("StationModBusInputVariables", typeof(ObservableCollection<ModBusInputVariable>), typeof(PlcDetails), new PropertyMetadata(null));

        public ObservableCollection<ModBusInputVariable> StationModBusInputVariables
        {
            get { return (ObservableCollection<ModBusInputVariable>)GetValue(StationModBusInputVariablesProperty); }
            set { SetValue(StationModBusInputVariablesProperty, value); }
        }

        public static readonly DependencyProperty StationModBusOutputVariablesProperty =
            DependencyProperty.Register("StationModBusOutputVariables", typeof(ObservableCollection<ModBusOutputVariable>), typeof(PlcDetails), new PropertyMetadata(null));

        public ObservableCollection<ModBusOutputVariable> StationModBusOutputVariables
        {
            get { return (ObservableCollection<ModBusOutputVariable>)GetValue(StationModBusOutputVariablesProperty); }
            set { SetValue(StationModBusOutputVariablesProperty, value); }
        }

        public static readonly DependencyProperty StartRecordingValuesProperty =
           DependencyProperty.Register("StartRecordingValues", typeof(RelayCommand), typeof(PlcDetails), new PropertyMetadata(null));

        public RelayCommand StartRecordingValues
        {
            get { return (RelayCommand)GetValue(StartRecordingValuesProperty); }
            set { SetValue(StartRecordingValuesProperty, value); }
        }

        public static readonly DependencyProperty StopRecordingValuesProperty =
           DependencyProperty.Register("StopRecordingValues", typeof(RelayCommand), typeof(PlcDetails), new PropertyMetadata(null));

        public RelayCommand StopRecordingValues
        {
            get { return (RelayCommand)GetValue(StopRecordingValuesProperty); }
            set { SetValue(StopRecordingValuesProperty, value); }
        }

        public static readonly DependencyProperty SendValuesProperty =
           DependencyProperty.Register("SendValues", typeof(RelayCommand), typeof(PlcDetails), new PropertyMetadata(null));

        public RelayCommand SendValues
        {
            get { return (RelayCommand)GetValue(SendValuesProperty); }
            set { SetValue(SendValuesProperty, value); }
        }

        public PlcDetails()
        {
            InitializeComponent();
        }
    }
}
