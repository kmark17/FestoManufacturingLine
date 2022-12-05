using CommunityToolkit.Mvvm.Messaging;
using FestoManufacturingLine_ModBus.Domain.Messages;
using FestoManufacturingLine_ModBus.WPF.State.OutputPath;
using FestoManufacturingLine_ModBus.WPF.State.PlcConfigurations;
using FestoManufacturingLine_ModBus.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FestoManufacturingLine_ModBus.WPF.ViewModels
{
    public class StartupViewModel : ViewModelBase
    {
        private Thread thread;

        public StartupViewModel(IStationStoreFactory stationStoreFactory, IDistributingStationStore distributingStationStore,
            ITestingStationStore testingStationStore, IProcessingStationStore processingStationStore, IPickAndPlaceStationStore pickAndPlaceStationStore,
            IHandlingStationStore handlingStationStore, IFluidicMusclePressStationStore fluidicMusclePressStationStore, ISortingStationStore sortingStationStore,
            IOutputPathStore outputPathStore)
        {
            thread = new Thread(new ThreadStart(() => InitiateStores(ref stationStoreFactory, ref distributingStationStore, ref testingStationStore, ref processingStationStore,
                ref pickAndPlaceStationStore, ref handlingStationStore, ref fluidicMusclePressStationStore, ref sortingStationStore, ref outputPathStore)));
            thread.Start();
        }

        private void InitiateStores(ref IStationStoreFactory stationStoreFactory, ref IDistributingStationStore distributingStationStore,
            ref ITestingStationStore testingStationStore, ref IProcessingStationStore processingStationStore, ref IPickAndPlaceStationStore pickAndPlaceStationStore,
            ref IHandlingStationStore handlingStationStore, ref IFluidicMusclePressStationStore fluidicMusclePressStationStore, ref ISortingStationStore sortingStationStore,
            ref IOutputPathStore outputPathStore)
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
            outputPathStore.FilePath = @"C:\FestoManufacturingLine\";

            WeakReferenceMessenger.Default.Send(new StartupCompletedMessage("Startup is done."));
        }
    }
}
