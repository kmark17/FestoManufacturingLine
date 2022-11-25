using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using FestoManufacturingLine_ModBus.WPF.ViewModels;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<ModbusClientViewModel>();
                services.AddSingleton<CreateViewModel<ManufacturingLineOverviewViewModel>>(services => () => CreateManufacturingLineOverviewViewModel(services));
                services.AddSingleton<CreateViewModel<DistributingStationViewModel>>(services => () => CreateDistributingStationViewModel(services));
                services.AddSingleton<CreateViewModel<TestingStationViewModel>>(services => () => CreateTestingStationViewModel(services));
                services.AddSingleton<CreateViewModel<ProcessingStationViewModel>>(services => () => CreateProcessingStationViewModel(services));
                services.AddSingleton<CreateViewModel<PickAndPlaceStationViewModel>>(services => () => CreatePickAndPlaceStationViewModel(services));
                services.AddSingleton<CreateViewModel<HandlingStationViewModel>>(services => () => CreateHandlingStationViewModel(services));
                services.AddSingleton<CreateViewModel<FluidicMusclePressStationViewModel>>(services => () => CreateFluidicMusclePressStationViewModel(services));
                services.AddSingleton<CreateViewModel<SortingStationViewModel>>(services => () => CreateSortingStationViewModel(services));
                services.AddSingleton<CreateViewModel<SettingsViewModel>>(services => () => CreateSettingsViewModel(services));
            });

            return host;
        }

        private static ManufacturingLineOverviewViewModel CreateManufacturingLineOverviewViewModel(IServiceProvider services)
        {
            return new ManufacturingLineOverviewViewModel();
        }

        private static DistributingStationViewModel CreateDistributingStationViewModel(IServiceProvider services)
        {
            return new DistributingStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<IDistributingStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static TestingStationViewModel CreateTestingStationViewModel(IServiceProvider services)
        {
            return new TestingStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<ITestingStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static ProcessingStationViewModel CreateProcessingStationViewModel(IServiceProvider services)
        {
            return new ProcessingStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<IProcessingStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static PickAndPlaceStationViewModel CreatePickAndPlaceStationViewModel(IServiceProvider services)
        {
            return new PickAndPlaceStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<IPickAndPlaceStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static HandlingStationViewModel CreateHandlingStationViewModel(IServiceProvider services)
        {
            return new HandlingStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<IHandlingStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static FluidicMusclePressStationViewModel CreateFluidicMusclePressStationViewModel(IServiceProvider services)
        {
            return new FluidicMusclePressStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<IFluidicMusclePressStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static SortingStationViewModel CreateSortingStationViewModel(IServiceProvider services)
        {
            return new SortingStationViewModel(
                services.GetRequiredService<ModbusClientViewModel>(),
                services.GetRequiredService<IStationStoreFactory>(),
                services.GetRequiredService<ISortingStationStore>(),
                services.GetRequiredService<IModbusVariableFactory>());
        }

        private static SettingsViewModel CreateSettingsViewModel(IServiceProvider services)
        {
            return new SettingsViewModel();
        }
    }
}
