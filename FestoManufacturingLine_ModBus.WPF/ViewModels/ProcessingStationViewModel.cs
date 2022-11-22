using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class ProcessingStationViewModel : ViewModelBase
    {
        private ModbusClient ProcessingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }

        public ProcessingStationViewModel(ModbusClientViewModel modbusClientViewModel)
        {
            ModbusClientViewModel = modbusClientViewModel;
        }


        private void Listen(object caller)
        {
            try
            {
                ProcessingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity("192.168.1.30", 504);
                ProcessingStationModeBusClient.Connect();
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
            string[]? QW = ModbusClientViewModel.ReadValues(ProcessingStationModeBusClient, 0, 8);

            if (QW is not null)
            {

            }
        }
    }
}
