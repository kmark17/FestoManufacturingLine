using FestoManufacturingLine_ModBus.Domain.Models;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels.Factories
{
    public interface IModbusVariableFactory
    {
        ObservableCollection<ModBusInputVariable>? CreateInputVariables(IPlcConfigurationStore plcConfigurationStore);
        ObservableCollection<ModBusOutputVariable>? CreateOutputVariables(IPlcConfigurationStore plcConfigurationStore);
    }
}
