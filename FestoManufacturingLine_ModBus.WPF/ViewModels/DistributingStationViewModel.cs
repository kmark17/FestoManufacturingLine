using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
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
        private ModbusClient DistributingStationModeBusClient { get; set; }
        private DispatcherTimer PollTimer { get; } = new DispatcherTimer();
        private ModbusClientViewModel ModbusClientViewModel { get; }
        public ObservableCollection<DistributingStationModBusVariable> DistributingStationModBusVariables { get; } = new ObservableCollection<DistributingStationModBusVariable>();

        public DistributingStationViewModel(ModbusClientViewModel modbusClientViewModel)
        {
            ModbusClientViewModel = modbusClientViewModel;

            // Initializing DataGrid ItemsSource
            {
                DistributingStationModBusVariables!.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixCylinderRetracted_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixCylinderEjected_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixVacuumSensor_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixLeftPosition_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixRightPosition_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixMagazineEmpty_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "ixNextStationIsFree_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxEjectWorkpiece_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxVacuumOn_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxVacuumOff_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxRotateLeft_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxRotateRight_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });

                DistributingStationModBusVariables.Add(new DistributingStationModBusVariable()
                {
                    VariableName = "qxUIState_ModBusTCP",
                    CurrentValue = null,
                    ValueToSend = null,
                });
            }

            //PollTimer.Interval = new TimeSpan(0, 0, 3);
            //PollTimer.Tick += PollTimer_Tick!;
            //PollTimer.Start();

            Listen(null);
        }
        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (DistributingStationModeBusClient.Connected)
            {
                //ReadValues();
                //Write();
            }
        }


        private void Listen(object caller)
        {
            try
            {
                DistributingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity("192.168.1.10", 502);
                DistributingStationModeBusClient.Connect();
                ReadValues();
            }
            catch (Exception)
            {
                throw new Exception();
            }

            //Read = new Thread(new ThreadStart(ReadValues));
            //Read.Start();

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
