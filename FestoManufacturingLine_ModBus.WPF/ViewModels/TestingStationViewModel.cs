using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class TestingStationViewModel : ViewModelBase
    {
        private ModbusClient TestingStationModeBusClient { get; set; }
        private ModbusClientViewModel ModbusClientViewModel { get; }

        public TestingStationViewModel(ModbusClientViewModel modbusClientViewModel)
        {
            ModbusClientViewModel = modbusClientViewModel;
        }


        private void Listen(object caller)
        {
            try
            {
                TestingStationModeBusClient = ModbusClientViewModel.ConfigureModBusEntity("192.168.1.20", 503);
                TestingStationModeBusClient.Connect();
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
            string[]? QW = ModbusClientViewModel.ReadValues(TestingStationModeBusClient, 0, 5);

            if (QW is not null)
            {

            }
        }
    }
}
