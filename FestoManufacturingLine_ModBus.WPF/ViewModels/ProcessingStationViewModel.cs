using CommunityToolkit.Mvvm.ComponentModel;
using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
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
        private bool _isDistributingStationOnline = true;
        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? DistributingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        public ObservableCollection<ModBusInputVariable>? DistributingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? DistributingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public ProcessingStationViewModel(ModbusClientViewModel modbusClientViewModel, IStationStoreFactory stationStoreFactory,
            IProcessingStationStore distributingStationStore, IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;


            distributingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("ProcessingStation");
            DistributingStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(distributingStationStore);
            DistributingStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(distributingStationStore);
            Listen();
        }

        //[RelayCommand]
        private void Listen()
        {
            try
            {
                DistributingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity("192.168.1.30", 504);
                DistributingStationModeBusClient.Connect();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            ReadThread = new Thread(new ThreadStart(ReadRegisters));
            ReadThread.Start();

            //tWrite = new Thread(new ThreadStart(Write));
            //tWrite.Start();
        }

        private void ReadRegisters()
        {
            int index = 1;

            using (StreamWriter sw = new StreamWriter
                (@"C:\Users\ee2805\OneDrive - tdkgroup\Dokumentumok\Egyetem\DigitalFactoryLab project\Data\ProcessingStation.txt"))
            {
                string? header = null;

                foreach (var DistributingStationModBusInputVariable in DistributingStationModBusInputVariables)
                {
                    if (header is null) header = DistributingStationModBusInputVariable.VariableName + ",";
                    else header += DistributingStationModBusInputVariable.VariableName + ",";
                }

                sw.WriteLine(header);

                while (true)
                {
                    string[]? QW = ModbusClientViewModel.ReadValues(DistributingStationModeBusClient, 0, 9);

                    if (QW is not null)
                    {
                        sw.WriteLine(string.Join(",", QW));
                    }

                    Thread.Sleep(1000);
                    index++;
                    if (index == 600) break;
                }
            }
        }
    }
}
