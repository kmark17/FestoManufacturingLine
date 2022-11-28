using FestoManufacturingLine_ModBus.WPF.State.OutputPath;
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
        public DistributingStationViewModel? DistributingStationViewModel { get; }
        public TestingStationViewModel? TestingStationViewModel { get; }
        public ProcessingStationViewModel? ProcessingStationViewModel { get; }
        public PickAndPlaceStationViewModel? PickAndPlaceStationViewModel { get; }
        public HandlingStationViewModel? HandlingStationViewModel { get; }
        public FluidicMusclePressStationViewModel? FluidicMusclePressStationViewModel { get; }
        public SortingStationViewModel? SortingStationViewModel { get; }
        public SettingsViewModel? SettingsViewModel { get; }

        public MainViewModel(IViewModelFactory viewModelFactory, IStationStoreFactory stationStoreFactory, IDistributingStationStore distributingStationStore,
            ITestingStationStore testingStationStore, IProcessingStationStore processingStationStore, IPickAndPlaceStationStore pickAndPlaceStationStore,
            IHandlingStationStore handlingStationStore, IFluidicMusclePressStationStore fluidicMusclePressStationStore, ISortingStationStore sortingStationStore,
            IOutputPathStore outputPathStore)
        {
            // Create Stores
            // Order here does matter, as sotres are used in viewmodels andthey must be
            // created first,otherwiese the program would crash because of null reference.
            // As every sotre object is registered as a singleton, they going to be only one
            // object throughout the life of the application.
            distributingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("DistributingStation");
            testingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("TestingStation");
            processingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("ProcessingStation");
            pickAndPlaceStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("PickAndPlaceStation");
            handlingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("HandlingStation");
            fluidicMusclePressStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("FluidicMusclePressStation");
            sortingStationStore!.PlcConfiguration = stationStoreFactory.CreatePlcConfiguration("SortingStation");

            // Default output file path.
            outputPathStore.FilePath = @"C:\";

            // Create ViewModels
            DistributingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Distributing) as DistributingStationViewModel;
            TestingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Testing) as TestingStationViewModel;
            ProcessingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Processing) as ProcessingStationViewModel;
            PickAndPlaceStationViewModel = viewModelFactory.CreateViewModel(ViewType.PickAndPlace) as PickAndPlaceStationViewModel;
            HandlingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Handling) as HandlingStationViewModel;
            FluidicMusclePressStationViewModel = viewModelFactory.CreateViewModel(ViewType.FluidicMusclePress) as FluidicMusclePressStationViewModel;
            SortingStationViewModel = viewModelFactory.CreateViewModel(ViewType.Sorting) as SortingStationViewModel;
            SettingsViewModel = viewModelFactory.CreateViewModel(ViewType.Settings) as SettingsViewModel;
        }
    }
}
