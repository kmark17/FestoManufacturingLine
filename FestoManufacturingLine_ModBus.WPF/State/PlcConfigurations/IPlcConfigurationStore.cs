using FestoManufacturingLine_ModBus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations
{
    public interface IPlcConfigurationStore
    {
        PlcConfiguration? PlcConfiguration { get; set; }
    }
}
