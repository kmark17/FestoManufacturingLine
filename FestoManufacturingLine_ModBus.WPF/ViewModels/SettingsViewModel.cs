using CommunityToolkit.Mvvm.ComponentModel;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        [ObservableProperty]
        private IDistributingStationStore? _distributingStationStore;

        [ObservableProperty]
        private ITestingStationStore? _testingStationStore;

        [ObservableProperty]
        private IProcessingStationStore? _processingStationStore;

        [ObservableProperty]
        private IPickAndPlaceStationStore? _pickAndPlaceStationStore;

        [ObservableProperty]
        private IHandlingStationStore? _handlingStationStore;

        [ObservableProperty]
        private IFluidicMusclePressStationStore? _fluidicMusclePressStationStore;

        [ObservableProperty]
        private ISortingStationStore? _sortingStationStore;
        public SettingsViewModel(IDistributingStationStore distributingStationStore, ITestingStationStore testingStationStore, IProcessingStationStore processingStationStore,
            IPickAndPlaceStationStore pickAndPlaceStationStore, IHandlingStationStore handlingStationStore, IFluidicMusclePressStationStore fluidicMusclePressStationStore,
            ISortingStationStore sortingStationStore)
        {
            DistributingStationStore = distributingStationStore;
            TestingStationStore = testingStationStore;
            ProcessingStationStore = processingStationStore;
            PickAndPlaceStationStore = pickAndPlaceStationStore;
            HandlingStationStore = handlingStationStore;
            FluidicMusclePressStationStore = fluidicMusclePressStationStore;
            SortingStationStore = sortingStationStore;
        }
    }
}
