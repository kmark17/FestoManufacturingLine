using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.Domain.Models
{
    public class PlcConfiguration
    {
        public string? Name { get; set; }
        public string? IpAddress { get; set; }
        public int? ModbusPortNumber { get; set; }
        public int? StartingAddress { get; set; }
        public int? NumberOfRegisters { get; set; }
        public IEnumerable<IConfigurationSection>? InputRegisterNames { get; set; }
        public IEnumerable<IConfigurationSection>? OutputRegisterNames { get; set; }
    }
}
