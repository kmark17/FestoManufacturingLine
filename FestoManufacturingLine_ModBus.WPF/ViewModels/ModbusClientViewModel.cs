using EasyModbus;
using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<ModBusInputVariable>? CreateInputVariables(IPlcConfigurationStore plcConfigurationStore)
        {
            ObservableCollection<ModBusInputVariable> modBusInputVariables = new ObservableCollection<ModBusInputVariable>();

            if (plcConfigurationStore.PlcConfiguration?.InputRegisterNames is null) return null;

            foreach (var inputRegisterName in plcConfigurationStore.PlcConfiguration.InputRegisterNames)
            {
                modBusInputVariables!.Add(new ModBusInputVariable()
                {
                    VariableName = inputRegisterName.Value,
                    CurrentValue = null,
                });
            }

            return modBusInputVariables;
        }

        public ObservableCollection<ModBusOutputVariable>? CreateOutputVariables(IPlcConfigurationStore plcConfigurationStore)
        {
            ObservableCollection<ModBusOutputVariable> modBusOutputVariables = new ObservableCollection<ModBusOutputVariable>();

            if (plcConfigurationStore.PlcConfiguration?.OutputRegisterNames is null) return null;

            foreach (var outputRegisterName in plcConfigurationStore.PlcConfiguration.OutputRegisterNames)
            {
                modBusOutputVariables!.Add(new ModBusOutputVariable()
                {
                    VariableName = outputRegisterName.Value,
                    ValueToSend = null,
                });
            }

            return modBusOutputVariables;
        }
    }
}
