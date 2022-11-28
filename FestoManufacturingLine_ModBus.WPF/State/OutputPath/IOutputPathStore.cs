using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.State.OutputPath
{
    public interface IOutputPathStore
    {
        string? FilePath { get; set; }
    }
}
