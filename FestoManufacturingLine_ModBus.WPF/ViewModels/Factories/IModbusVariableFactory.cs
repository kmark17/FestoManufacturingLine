using FestoManufacturingLine_ModBus.Domain.Models;
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
        ObservableCollection<ModBusInputVariable> CreateInputVariables(string stationName);
        ObservableCollection<ModBusOutputVariable> CreateOutputVariables(string stationName);
    }
}
