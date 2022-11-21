using EasyModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class ModbusClientViewModel : ViewModelBase
    {
        public ModbusClientViewModel()
        {
        }

        public ModbusClient ConfigureModBusEntity(string ipAddress, int port)
        {
            ModbusClient modbusClient = new ModbusClient();

            modbusClient.IPAddress = ipAddress;
            modbusClient.Port = port;
            modbusClient.ConnectionTimeout = 5000;

            return modbusClient;
        }

        public string[]? ReadValues(ModbusClient modbusClient, int startingAddress, int quantity)
        {
            int[] readInputRegisters;

            if (modbusClient.Connected)
            {
                readInputRegisters = modbusClient.ReadInputRegisters(startingAddress, quantity);

                string[] QW = new string[quantity];

                for (int i = 0; i < quantity; ++i)
                {
                    QW[i] = readInputRegisters[i].ToString();
                }

                return QW;
            }

            return null;
        }

        public void WriteValues()
        {
            //if (modeBusClient.Connected)
            //{
            //    int[] writeValues = new int[]
            //    {
            //        //int.Parse(QW1TextBlock.Text),
            //    };

            //    modeBusClient.WriteMultipleRegisters(0, writeValues);
            //}
        }
    }
}
