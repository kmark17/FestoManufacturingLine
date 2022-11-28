using System;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels.Factories
{
    /// <summary>
    /// Creates a new ViewModel.
    /// </summary>
    public class ViewModelFactory : IViewModelFactory
    {
        private CreateViewModel<DistributingStationViewModel> CreateDistributingStationViewModel { get; }
        private CreateViewModel<TestingStationViewModel> CreateTestingStationViewModel { get; }
        private CreateViewModel<ProcessingStationViewModel> CreateProcessingStationViewModel { get; }
        private CreateViewModel<PickAndPlaceStationViewModel> CreatePickAndPlaceStationViewModel { get; }
        private CreateViewModel<HandlingStationViewModel> CreateHandlingStationViewModel { get; }
        private CreateViewModel<FluidicMusclePressStationViewModel> CreateFluidicMusclePressStationViewModel { get; }
        private CreateViewModel<SortingStationViewModel> CreateSortingStationViewModel { get; }
        private CreateViewModel<SettingsViewModel> CreateSettingsViewModel { get; }

        public ViewModelFactory(CreateViewModel<DistributingStationViewModel> createDistributingStationViewModel,
            CreateViewModel<TestingStationViewModel> createTestingStationViewModel, CreateViewModel<ProcessingStationViewModel> createProcessingStationViewModel,
            CreateViewModel<PickAndPlaceStationViewModel> createPickAndPlaceStationViewModel, CreateViewModel<HandlingStationViewModel> createHandlingStationViewModel,
            CreateViewModel<FluidicMusclePressStationViewModel> createFluidicMusclePressStationViewModel, CreateViewModel<SortingStationViewModel> createSortingStationViewModel,
            CreateViewModel<SettingsViewModel> createSettingsViewModel)
        {
            CreateDistributingStationViewModel = createDistributingStationViewModel;
            CreateTestingStationViewModel = createTestingStationViewModel;
            CreateProcessingStationViewModel = createProcessingStationViewModel;
            CreatePickAndPlaceStationViewModel = createPickAndPlaceStationViewModel;
            CreateHandlingStationViewModel = createHandlingStationViewModel;
            CreateFluidicMusclePressStationViewModel = createFluidicMusclePressStationViewModel;
            CreateSortingStationViewModel = createSortingStationViewModel;
            CreateSettingsViewModel = createSettingsViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Distributing:
                    return CreateDistributingStationViewModel();

                case ViewType.Testing:
                    return CreateTestingStationViewModel();

                case ViewType.Processing:
                    return CreateProcessingStationViewModel();

                case ViewType.PickAndPlace:
                    return CreatePickAndPlaceStationViewModel();

                case ViewType.Handling:
                    return CreateHandlingStationViewModel();

                case ViewType.FluidicMusclePress:
                    return CreateFluidicMusclePressStationViewModel();

                case ViewType.Sorting:
                    return CreateSortingStationViewModel();

                case ViewType.Settings:
                    return CreateSettingsViewModel();

                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
