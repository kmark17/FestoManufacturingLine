using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels.Factories
{
    public class ModbusVariableFactory : IModbusVariableFactory
    {
        public ModbusVariableFactory()
        {
        }

        public ObservableCollection<ModBusInputVariable>? CreateInputVariables(IPlcConfigurationStore plcConfigurationStore)
        {
            ObservableCollection<ModBusInputVariable> modBusInputVariables = new ObservableCollection<ModBusInputVariable>();

            if (plcConfigurationStore.PlcConfiguration?.InputRegisterNames is null) return null;

            foreach (var inputRegisterName in plcConfigurationStore.PlcConfiguration.InputRegisterNames)
            {
                modBusInputVariables!.Add(new ModBusInputVariable()
                {
                    VariableName = inputRegisterName,
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
                    VariableName = outputRegisterName,
                    ValueToSend = null,
                });
            }

            return modBusOutputVariables;
        }
    }
}
