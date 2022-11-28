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
    public partial class FluidicMusclePressStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isFluidicMusclePressStationOnline = false;

        [ObservableProperty]
        private bool _isListening = true;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? FluidicMusclePressStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private IFluidicMusclePressStationStore FluidicMusclePressStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? FluidicMusclePressStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? FluidicMusclePressStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public FluidicMusclePressStationViewModel(ModbusClientViewModel modbusClientViewModel, IFluidicMusclePressStationStore fluidicMusclePressStationStore, IOutputPathStore outputPathStore,
            IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;
            FluidicMusclePressStationStore = fluidicMusclePressStationStore;
            OutputPathStore = outputPathStore;

            FluidicMusclePressStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(fluidicMusclePressStationStore);
            FluidicMusclePressStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(fluidicMusclePressStationStore);
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
                FluidicMusclePressStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    FluidicMusclePressStationStore.PlcConfiguration!.IpAddress!,
                    FluidicMusclePressStationStore.PlcConfiguration.ModbusPortNumber);
                FluidicMusclePressStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                FluidicMusclePressStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                FluidicMusclePressStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    FluidicMusclePressStationStore.PlcConfiguration!.IpAddress!,
                    FluidicMusclePressStationStore.PlcConfiguration.ModbusPortNumber);
                FluidicMusclePressStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                FluidicMusclePressStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + FluidicMusclePressStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in FluidicMusclePressStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (FluidicMusclePressStationModeBusClient!,
                            FluidicMusclePressStationStore.PlcConfiguration!.StartingAddress,
                            FluidicMusclePressStationStore.PlcConfiguration.NumberOfRegisters);

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
                FluidicMusclePressStationModeBusClient!.Disconnect();
                FluidicMusclePressStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (FluidicMusclePressStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[FluidicMusclePressStationModBusOutputVariables!.Count];

                    for (int i = 0; i < FluidicMusclePressStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = FluidicMusclePressStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    FluidicMusclePressStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                FluidicMusclePressStationModeBusClient!.Disconnect();
                FluidicMusclePressStationModeBusClient = null;
            }
        }
    }
}
