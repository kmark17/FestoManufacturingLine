using FestoManufacturingLine_ModBus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels.Factories
{
    public interface IStationStoreFactory
    {
        PlcConfiguration CreatePlcConfiguration(string stationName);
    }
}
