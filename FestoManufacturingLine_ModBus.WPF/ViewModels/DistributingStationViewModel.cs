using CommunityToolkit.Mvvm.ComponentModel;
using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.IO;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using FestoManufacturingLine_ModBus.WPF.State.OutputPath;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public partial class DistributingStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isDistributingStationOnline;

        [ObservableProperty]
        private bool _isListening = false;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? DistributingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private IDistributingStationStore DistributingStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? DistributingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? DistributingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public DistributingStationViewModel(ModbusClientViewModel modbusClientViewModel, IDistributingStationStore distributingStationStore, IOutputPathStore outputPathStore,
            IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;
            DistributingStationStore = distributingStationStore;
            OutputPathStore = outputPathStore;

            IsDistributingStationOnline = distributingStationStore.PlcConfiguration!.IsStationOnline;

            DistributingStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(distributingStationStore);
            DistributingStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(distributingStationStore);
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
                DistributingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    DistributingStationStore.PlcConfiguration!.IpAddress!,
                    DistributingStationStore.PlcConfiguration.ModbusPortNumber);
                DistributingStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DistributingStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                DistributingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    DistributingStationStore.PlcConfiguration!.IpAddress!,
                    DistributingStationStore.PlcConfiguration.ModbusPortNumber);
                DistributingStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                DistributingStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + DistributingStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in DistributingStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (DistributingStationModeBusClient!,
                            DistributingStationStore.PlcConfiguration!.StartingAddress,
                            DistributingStationStore.PlcConfiguration.NumberOfRegisters);

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
                DistributingStationModeBusClient!.Disconnect();
                DistributingStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (DistributingStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[DistributingStationModBusOutputVariables!.Count];

                    for (int i = 0; i < DistributingStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = DistributingStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    DistributingStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                DistributingStationModeBusClient!.Disconnect();
                DistributingStationModeBusClient = null;
            }
        }
    }
}
