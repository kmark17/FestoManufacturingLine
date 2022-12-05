using CommunityToolkit.Mvvm.Messaging;
using FestoManufacturingLine_ModBus.Domain.Messages;
using FestoManufacturingLine_ModBus.WPF.HostBuilders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
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
        private bool IsStartupCompleted { get; set; } = false;

        public App()
        {
            _host = CreateHostBuilder().Build();

            WeakReferenceMessenger.Default.Register<StartupCompletedMessage>(this, (r, m) => { IsStartupCompleted = true; });
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

            // Let the startup screen render.
            await Task.Delay(2000);

            // Kinda sloppy but makes the job done.
            while (!IsStartupCompleted)
            {
                await Task.Delay(1000);
            }

            Window mainWindow = _host.Services.GetRequiredService<MainWindow>();

            mainWindow.Show();
            startUpWindow.Close();

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
