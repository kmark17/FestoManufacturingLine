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
    public partial class ProcessingStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isProcessingStationOnline = false;

        [ObservableProperty]
        private bool _isListening = false;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? ProcessingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private IProcessingStationStore ProcessingStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? ProcessingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? ProcessingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public ProcessingStationViewModel(ModbusClientViewModel modbusClientViewModel, IProcessingStationStore processingStationStore, IOutputPathStore outputPathStore)
        {
            ModbusClientViewModel = modbusClientViewModel;
            ProcessingStationStore = processingStationStore;
            OutputPathStore = outputPathStore;

            IsProcessingStationOnline = processingStationStore.PlcConfiguration!.IsStationOnline;

            ProcessingStationModBusInputVariables = modbusClientViewModel.CreateInputVariables(processingStationStore);
            ProcessingStationModBusOutputVariables = modbusClientViewModel.CreateOutputVariables(processingStationStore);
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
                ProcessingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    ProcessingStationStore.PlcConfiguration!.IpAddress!,
                    ProcessingStationStore.PlcConfiguration.ModbusPortNumber);
                ProcessingStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ProcessingStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                ProcessingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    ProcessingStationStore.PlcConfiguration!.IpAddress!,
                    ProcessingStationStore.PlcConfiguration.ModbusPortNumber);
                ProcessingStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ProcessingStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + ProcessingStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in ProcessingStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (ProcessingStationModeBusClient!,
                            ProcessingStationStore.PlcConfiguration!.StartingAddress,
                            ProcessingStationStore.PlcConfiguration.NumberOfRegisters);

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
                ProcessingStationModeBusClient!.Disconnect();
                ProcessingStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (ProcessingStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[ProcessingStationModBusOutputVariables!.Count];

                    for (int i = 0; i < ProcessingStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = ProcessingStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    ProcessingStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                ProcessingStationModeBusClient!.Disconnect();
                ProcessingStationModeBusClient = null;
            }
        }
    }
}
