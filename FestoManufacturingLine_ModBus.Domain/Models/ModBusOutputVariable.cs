using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.Domain.Models
{
    public class ModBusOutputVariable
    {
        public string? VariableName { get; set; }
        public int? CurrentValue { get; set; }
        public int? ValueToSend { get; set; }
    }
}
