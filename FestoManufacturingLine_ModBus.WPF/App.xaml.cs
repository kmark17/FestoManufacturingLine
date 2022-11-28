using FestoManufacturingLine_ModBus.WPF.HostBuilders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FestoManufacturingLine_ModBus.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddServices()
                .AddStores()
                .AddViewModels()
                .AddViews();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window startUpWindow = _host.Services.GetRequiredService<StartUpWindow>();
            startUpWindow.Show();

            await Task.Delay(1500);

            Window mainWindow = _host.Services.GetRequiredService<MainWindow>();
            startUpWindow.Close();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
