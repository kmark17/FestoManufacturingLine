using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices((services) =>
            {
                services.AddSingleton<IDistributingStationStore, DistributingStationStore>();
            });

            return host;
        }
    }
}
