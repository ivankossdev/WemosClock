using CommunityToolkit.Mvvm.ComponentModel;


namespace WemosClock.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private object _currentViewModel;

    public SearchViewModel SearchVM { get; }

    public MainWindowViewModel(SearchViewModel searchViewModel)
    {
        SearchVM = searchViewModel;
        CurrentViewModel = searchViewModel;
        
    }
}