using FestoManufacturingLine_ModBus.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels.Factories
{
    public class StationStoreFactory : IStationStoreFactory
    {
        private IConfiguration PlcConfigurations { get; }

        public StationStoreFactory(IConfiguration plcConfigurations)
        {
            PlcConfigurations = plcConfigurations;
        }

        public PlcConfiguration CreatePlcConfiguration(string stationName)
        {
            IEnumerable<IConfigurationSection> inputRegisterNames = PlcConfigurations.GetSection(stationName).GetSection("InputRegisterNames").GetChildren();

            PlcConfiguration plcConfiguration = new PlcConfiguration()
            {
                InputRegisterNames = inputRegisterNames,
            };

            return plcConfiguration;
        }
    }
}
