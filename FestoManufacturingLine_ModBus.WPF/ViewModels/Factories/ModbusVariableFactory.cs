using FestoManufacturingLine_ModBus.Domain.Models;
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
        private IConfiguration PlcConfigurations { get; }

        public ModbusVariableFactory(IConfiguration plcConfigurations)
        {
            PlcConfigurations = plcConfigurations;
        }

        public ObservableCollection<ModBusInputVariable> CreateInputVariables(string stationName)
        {
            IEnumerable<IConfigurationSection> inputRegisterNames = PlcConfigurations.GetSection(stationName).GetSection("InputRegisterNames").GetChildren();
            ObservableCollection<ModBusInputVariable> modBusInputVariables = new ObservableCollection<ModBusInputVariable>();

            foreach (var inputRegisterName in inputRegisterNames)
            {
                modBusInputVariables!.Add(new ModBusInputVariable()
                {
                    VariableName = inputRegisterName?.Value,
                    CurrentValue = null,
                });
            }

            return modBusInputVariables;
        }

        public ObservableCollection<ModBusOutputVariable> CreateOutputVariables(string stationName)
        {
            IEnumerable<IConfigurationSection> outputRegisterNames = PlcConfigurations.GetSection(stationName).GetSection("OutputRegisterNames").GetChildren();
            ObservableCollection<ModBusOutputVariable> modBusOutputVariables = new ObservableCollection<ModBusOutputVariable>();

            foreach (var outputRegisterName in outputRegisterNames)
            {
                modBusOutputVariables!.Add(new ModBusOutputVariable()
                {
                    VariableName = outputRegisterName?.Value,
                    CurrentValue = null,
                    ValueToSend = null,
                });
            }

            return modBusOutputVariables;
        }
    }
}
