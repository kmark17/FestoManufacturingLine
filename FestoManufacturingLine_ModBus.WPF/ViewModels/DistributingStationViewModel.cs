using CommunityToolkit.Mvvm.ComponentModel;
using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using Microsoft.Extensions.Configuration;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Options;
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

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public partial class DistributingStationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isDistributingStationOnline = true;
        private Thread? ReadThread { get; set; }
        private Thread? WriteThread { get; set; }
        private ModbusClient? DistributingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        public ObservableCollection<ModBusInputVariable>? DistributingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable>? DistributingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public DistributingStationViewModel(ModbusClientViewModel modbusClientViewModel, IStationStoreFactory stationStoreFactory,
            IDistributingStationStore distributingStationStore, IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;


            distributingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("DistributingStation");
            DistributingStationModBusInputVariables = modbusVariableFactory.CreateInputVariables(distributingStationStore);
            DistributingStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables(distributingStationStore);
            Listen();
        }

        //[RelayCommand]
        private void Listen()
        {
            try
            {
                DistributingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity("192.168.1.10", 502);
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
                (@"C:\Users\ee2805\OneDrive - tdkgroup\Dokumentumok\Egyetem\DigitalFactoryLab project\Data\DistributingStation.txt"))
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
                    string[]? QW = ModbusClientViewModel.ReadValues(DistributingStationModeBusClient, 0, 7);

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

        private void WriteRegisters()
        {
            if (DistributingStationModeBusClient.Connected)
            {
                int[] writeValues = new int[]
                {
                    //int.Parse(QW1TextBlock.Text),
                    //int.Parse(QW2TextBlock.Text),
                    //int.Parse(QW3TextBlock.Text),
                    //int.Parse(QW4TextBlock.Text),
                    //int.Parse(QW5TextBlock.Text),
                    //int.Parse(QW6TextBlock.Text),
                    //int.Parse(QW7TextBlock.Text),
                    //int.Parse(QW8TextBlock.Text),
                    //int.Parse(QW9TextBlock.Text),
                    //int.Parse(QW10TextBlock.Text),
                };

                DistributingStationModeBusClient.WriteMultipleRegisters(0, writeValues);
            }
        }

        private void AlwaysRunning()
        {
            while (true)
            {
                if (DistributingStationModeBusClient.Connected)
                {
                    // ToDo
                }
                else
                {
                    // ToDo
                }
            }
        }
    }
}
