using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.Domain.Messages
{
    public class StartupCompletedMessage : ValueChangedMessage<string>
    {
        public StartupCompletedMessage(string message) : base(message)
        {
        }
    }
}
