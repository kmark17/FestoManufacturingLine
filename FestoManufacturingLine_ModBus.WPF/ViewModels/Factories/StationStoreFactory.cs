using FestoManufacturingLine_ModBus.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
            IConfigurationSection name = PlcConfigurations.GetSection(stationName).GetSection("Name");
            IConfigurationSection ipAddress = PlcConfigurations.GetSection(stationName).GetSection("IPAddress");
            IConfigurationSection modbusPortNumber = PlcConfigurations.GetSection(stationName).GetSection("ModbusPortNumber");
            IConfigurationSection startingAddress = PlcConfigurations.GetSection(stationName).GetSection("StartingAddress");
            IConfigurationSection numberOfRegisters = PlcConfigurations.GetSection(stationName).GetSection("NumberOfRegisters");
            IEnumerable<IConfigurationSection> inputRegisterNames = PlcConfigurations.GetSection(stationName).GetSection("InputRegisterNames").GetChildren();
            IEnumerable<IConfigurationSection> outputRegisterNames = PlcConfigurations.GetSection(stationName).GetSection("OutputRegisterNames").GetChildren();

            PlcConfiguration plcConfiguration = new PlcConfiguration()
            {
                Name = name?.Value,
                IpAddress = ipAddress?.Value,
                ModbusPortNumber = int.Parse(modbusPortNumber.Value!),
                StartingAddress = int.Parse(startingAddress.Value!),
                NumberOfRegisters = int.Parse(numberOfRegisters.Value!),
                IsStationOnline = PingHost(ipAddress?.Value),
                InputRegisterNames = inputRegisterNames,
                OutputRegisterNames = outputRegisterNames,
            };

            return plcConfiguration;
        }

        private bool PingHost(string? ipAddress)
        {
            if (ipAddress is null) return false;

            bool pingable = false;

            try
            {
                using (var pinger = new Ping())
                {
                    PingReply reply = pinger.Send(ipAddress, 1000);
                    pingable = reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                return false;
            }

            return pingable;
        }
    }
}
