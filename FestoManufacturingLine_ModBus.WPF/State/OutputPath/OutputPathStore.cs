using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.State.OutputPath
{
    public class OutputPathStore : IOutputPathStore
    {
        private string? _filePath;
        public string? FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
            }
        }
    }
}
