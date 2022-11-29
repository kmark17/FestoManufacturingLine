using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.State.OutputPath;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public partial class PickAndPlaceStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isPickAndPlaceStationOnline = false;

        [ObservableProperty]
        private bool _isListening = false;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? PickAndPlaceStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private IPickAndPlaceStationStore PickAndPlaceStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? PickAndPlaceStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? PickAndPlaceStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public PickAndPlaceStationViewModel(ModbusClientViewModel modbusClientViewModel, IPickAndPlaceStationStore pickAndPlaceStationStore, IOutputPathStore outputPathStore,
            IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;
            PickAndPlaceStationStore = pickAndPlaceStationStore;
            OutputPathStore = outputPathStore;

            IsPickAndPlaceStationOnline = pickAndPlaceStationStore.PlcConfiguration!.IsStationOnline;

            PickAndPlaceStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(pickAndPlaceStationStore);
            PickAndPlaceStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(pickAndPlaceStationStore);
        }

        [RelayCommand]
        private void Stop()
        {
            IsListening = false;
        }

        [RelayCommand]
        private void Listen()
        {
            try
            {
                PickAndPlaceStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    PickAndPlaceStationStore.PlcConfiguration!.IpAddress!,
                    PickAndPlaceStationStore.PlcConfiguration.ModbusPortNumber);
                PickAndPlaceStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                PickAndPlaceStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                PickAndPlaceStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    PickAndPlaceStationStore.PlcConfiguration!.IpAddress!,
                    PickAndPlaceStationStore.PlcConfiguration.ModbusPortNumber);
                PickAndPlaceStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                PickAndPlaceStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + PickAndPlaceStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in PickAndPlaceStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (PickAndPlaceStationModeBusClient!,
                            PickAndPlaceStationStore.PlcConfiguration!.StartingAddress,
                            PickAndPlaceStationStore.PlcConfiguration.NumberOfRegisters);

                        if (QW is not null)
                        {
                            sw.WriteLine(string.Join(",", QW));
                        }

                        Thread.Sleep(1000);
                    }
                }
            }
            finally
            {
                PickAndPlaceStationModeBusClient!.Disconnect();
                PickAndPlaceStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (PickAndPlaceStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[PickAndPlaceStationModBusOutputVariables!.Count];

                    for (int i = 0; i < PickAndPlaceStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = PickAndPlaceStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    PickAndPlaceStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                PickAndPlaceStationModeBusClient!.Disconnect();
                PickAndPlaceStationModeBusClient = null;
            }
        }
    }
}
