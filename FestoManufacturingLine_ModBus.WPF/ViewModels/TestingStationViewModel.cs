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
    public partial class TestingStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isTestingStationOnline = false;

        [ObservableProperty]
        private bool _isListening = false;

        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? TestingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        private ITestingStationStore TestingStationStore { get; set; }
        private IOutputPathStore OutputPathStore { get; set; }
        public ObservableCollection<ModBusInputVariable>? TestingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? TestingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public TestingStationViewModel(ModbusClientViewModel modbusClientViewModel, ITestingStationStore testingStationStore, IOutputPathStore outputPathStore,
            IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;
            TestingStationStore = testingStationStore;
            OutputPathStore = outputPathStore;

            IsTestingStationOnline = testingStationStore.PlcConfiguration!.IsStationOnline;

            TestingStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(testingStationStore);
            TestingStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(testingStationStore);
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
                TestingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    TestingStationStore.PlcConfiguration!.IpAddress!,
                    TestingStationStore.PlcConfiguration.ModbusPortNumber);
                TestingStationModeBusClient.Connect();
                IsListening = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TestingStationModeBusClient = null;
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();
        }

        [RelayCommand]
        private void Send()
        {
            try
            {
                TestingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity(
                    TestingStationStore.PlcConfiguration!.IpAddress!,
                    TestingStationStore.PlcConfiguration.ModbusPortNumber);
                TestingStationModeBusClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TestingStationModeBusClient = null;
            }

            WriteThread = new Thread(new ThreadStart(WriteRegisters));
            WriteThread.Start();
        }

        private void ReadRegisters()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(OutputPathStore.FilePath! + TestingStationStore.PlcConfiguration!.Name))
                {
                    string? header = null;

                    foreach (var modBusInputVariable in TestingStationModBusInputVariables!)
                    {
                        if (header is null) header = modBusInputVariable.VariableName + ",";
                        else header += modBusInputVariable.VariableName + ",";
                    }

                    sw.WriteLine(header);

                    while (IsListening)
                    {
                        string[]? QW = ModbusClientViewModel.ReadValues
                            (TestingStationModeBusClient!,
                            TestingStationStore.PlcConfiguration!.StartingAddress,
                            TestingStationStore.PlcConfiguration.NumberOfRegisters);

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
                TestingStationModeBusClient!.Disconnect();
                TestingStationModeBusClient = null;
            }
        }

        private void WriteRegisters()
        {
            try
            {
                if (TestingStationModeBusClient!.Connected)
                {
                    int[] writeValues = new int[TestingStationModBusOutputVariables!.Count];

                    for (int i = 0; i < TestingStationModBusOutputVariables!.Count; i++)
                    {
                        writeValues[i] = TestingStationModBusOutputVariables[i].ValueToSend ?? 0;
                    }

                    TestingStationModeBusClient.WriteMultipleRegisters(0, writeValues);
                }
            }
            finally
            {
                TestingStationModeBusClient!.Disconnect();
                TestingStationModeBusClient = null;
            }
        }
    }
}
