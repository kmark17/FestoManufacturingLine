using System;
using System.Collections.Generic;
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
        public string[]? InputRegisterNames { get; set; }
        public string[]? OutputRegisterNames { get; set; }
    }
}
