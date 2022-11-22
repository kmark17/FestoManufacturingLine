using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class DistributingStationViewModel : ViewModelBase
    {
        private Thread? Read { get; set; }
        private Thread? Write { get; set; }
        private ModbusClient? DistributingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }
        public ObservableCollection<ModBusInputVariable> DistributingStationModBusInputVariables { get; } = new ObservableCollection<ModBusInputVariable>();
        public ObservableCollection<ModBusOutputVariable> DistributingStationModBusOutputVariables { get; } = new ObservableCollection<ModBusOutputVariable>();

        public DistributingStationViewModel(ModbusClientViewModel modbusClientViewModel, IModbusVariableFactory modbusVariableFactory)
        {
            ModbusClientViewModel = modbusClientViewModel;

            DistributingStationModBusInputVariables = modbusVariableFactory.CreateInputVariables("DistributingStation");
            DistributingStationModBusOutputVariables = modbusVariableFactory.CreateOutputVariables("DistributingStation");
        }

        private void Listen(object caller)
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

            Read = new Thread(new ThreadStart(ReadValues));
            Read.Start();

            //tWrite = new Thread(new ThreadStart(Write));
            //tWrite.Start();
        }

        private void ReadValues()
        {
            string[]? QW = ModbusClientViewModel.ReadValues(DistributingStationModeBusClient, 0, 6);

            if (QW is not null)
            {

            }
        }
    }
}
