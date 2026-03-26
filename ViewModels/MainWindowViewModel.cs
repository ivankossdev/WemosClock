using CommunityToolkit.Mvvm.ComponentModel;

namespace WemosClock.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _greeting = "Поиск устройств";

        public SearchViewModel SearchVM { get; } = new SearchViewModel();
    }
}