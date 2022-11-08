namespace FestoManufacturingLine_ModBus.WPF.ViewModels.Factories
{
    public enum ViewType
    {
        Overview,
        Distributing,
        Testing,
        Processing,
        PickAndPlace,
        Handling,
        FluidicMusclePress,
        Sorting,
        Settings,
    }

    public interface IViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
