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
    public partial class SortingStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isSortingStationOnline = false;

        [ObservableProperty]
        private bool _isListening = false;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? SortingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private ISortingStationStore SortingStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? SortingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? SortingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public SortingStationViewModel(ModbusClientViewModel modbusClientViewModel, ISortingStationStore sortingStationStore, IOutputPathStore outputPathStore)
        {
            ModbusClientViewModel = modbusClientViewModel;
            SortingStationStore = sortingStationStore;
            OutputPathStore = outputPathStore;

            IsSortingStationOnline = sortingStationStore.PlcConfiguration!.IsStationOnline;

            SortingStationModBusInputVariables = modbusClientViewModel.CreateInputVariables(sortingStationStore);
            SortingStationModBusOutputVariables = modbusClientViewModel.CreateOutputVariables(sortingStationStore);
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
                SortingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    SortingStationStore.PlcConfiguration!.IpAddress!,
                    SortingStationStore.PlcConfiguration.ModbusPortNumber);
                SortingStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                SortingStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                SortingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    SortingStationStore.PlcConfiguration!.IpAddress!,
                    SortingStationStore.PlcConfiguration.ModbusPortNumber);
                SortingStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                SortingStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + SortingStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in SortingStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (SortingStationModeBusClient!,
                            SortingStationStore.PlcConfiguration!.StartingAddress,
                            SortingStationStore.PlcConfiguration.NumberOfRegisters);

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
                SortingStationModeBusClient!.Disconnect();
                SortingStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (SortingStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[SortingStationModBusOutputVariables!.Count];

                    for (int i = 0; i < SortingStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = SortingStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    SortingStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                SortingStationModeBusClient!.Disconnect();
                SortingStationModeBusClient = null;
            }
        }
    }
}
