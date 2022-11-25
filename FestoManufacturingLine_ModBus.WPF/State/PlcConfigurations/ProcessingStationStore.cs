using FestoManufacturingLine_ModBus.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations
{
    public class ProcessingStationStore : IProcessingStationStore
    {
        private PlcConfiguration? _plcConfiguration;
        public PlcConfiguration? PlcConfiguration
        {
            get
            {
                return _plcConfiguration;
            }
            set
            {
                _plcConfiguration = value;
            }
        }
    }
}
