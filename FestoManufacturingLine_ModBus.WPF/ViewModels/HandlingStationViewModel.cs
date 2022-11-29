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
    public partial class HandlingStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isHandlingStationOnline = false;

        [ObservableProperty]
        private bool _isListening = false;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? HandlingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private IHandlingStationStore HandlingStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? HandlingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? HandlingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public HandlingStationViewModel(ModbusClientViewModel modbusClientViewModel, IHandlingStationStore handlingStationStore, IOutputPathStore outputPathStore,
            IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;
            HandlingStationStore = handlingStationStore;
            OutputPathStore = outputPathStore;

            HandlingStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(handlingStationStore);
            HandlingStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(handlingStationStore);
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
                HandlingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    HandlingStationStore.PlcConfiguration!.IpAddress!,
                    HandlingStationStore.PlcConfiguration.ModbusPortNumber);
                HandlingStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                HandlingStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                HandlingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    HandlingStationStore.PlcConfiguration!.IpAddress!,
                    HandlingStationStore.PlcConfiguration.ModbusPortNumber);
                HandlingStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                HandlingStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + HandlingStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in HandlingStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (HandlingStationModeBusClient!,
                            HandlingStationStore.PlcConfiguration!.StartingAddress,
                            HandlingStationStore.PlcConfiguration.NumberOfRegisters);

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
                HandlingStationModeBusClient!.Disconnect();
                HandlingStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (HandlingStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[HandlingStationModBusOutputVariables!.Count];

                    for (int i = 0; i < HandlingStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = HandlingStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    HandlingStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                HandlingStationModeBusClient!.Disconnect();
                HandlingStationModeBusClient = null;
            }
        }
    }
}
