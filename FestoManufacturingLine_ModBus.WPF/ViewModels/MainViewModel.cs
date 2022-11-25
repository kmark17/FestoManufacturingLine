using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ManufacturingLineOverviewViewModel? ManufacturingLineOverviewViewModel { get; }
        public DistributingStationViewModel? DistributingStationViewModel { get; }
        public TestingStationViewModel? TestingStationViewModel { get; }
        public ProcessingStationViewModel? ProcessingStationViewModel { get; }
        public PickAndPlaceStationViewModel? PickAndPlaceStationViewModel { get; }
        public HandlingStationViewModel? HandlingStationViewModel { get; }
        public FluidicMusclePressStationViewModel? FluidicMusclePressStationViewModel { get; }
        public SortingStationViewModel? SortingStationViewModel { get; }
        public SettingsViewModel? SettingsViewModel { get; }
        public IDistributingStationStore? DistributingStationStore { get; }
        public TestingStationStore? TestingStationStore { get; }
        public ProcessingStationStore? ProcessingStationStore { get; }
        public PickAndPLaceStationStore? PickAndPLaceStationStore { get; }
        public HandlingStationStore? HandlingStationStore { get; }
        public FluidicMusclePressStationStore? FluidicMusclePressStationStore { get; }
        public SortingStationStore? SortingStationStore { get; }

        public MainViewModel(IViewModelFactory viewModelFactory, IStationStoreFactory stationStoreFactory, IDistributingStationStore distributingStationStore)
        {
            // Create ViewModels
            ManufacturingLineOverviewViewModel = viewModelFactory.CreateViewModel(ViewType.Overview) as ManufacturingLineOverviewViewModel;
            DistributingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Distributing) as DistributingStationViewModel;
            TestingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Testing) as TestingStationViewModel;
            ProcessingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Processing) as ProcessingStationViewModel;
            PickAndPlaceStationViewModel = viewModelFactory.CreateViewModel(ViewType.PickAndPlace) as PickAndPlaceStationViewModel;
            HandlingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Handling) as HandlingStationViewModel;
            FluidicMusclePressStationViewModel = viewModelFactory.CreateViewModel(ViewType.FluidicMusclePress) as FluidicMusclePressStationViewModel;
            SortingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Sorting) as SortingStationViewModel;
            SettingsViewModel = viewModelFactory.CreateViewModel(ViewType.Settings) as SettingsViewModel;

            // Create Stores
            DistributingStationStore = distributingStationStore;
            DistributingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("DistributingStation");
        }
    }
}
