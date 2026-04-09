using CommunityToolkit.Mvvm.ComponentModel;


namespace WemosClock.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Поиск устройств";

    public SearchViewModel SearchVM { get; }

    public MainWindowViewModel(SearchViewModel searchViewModel)
    {
        SearchVM = searchViewModel;
    }
}