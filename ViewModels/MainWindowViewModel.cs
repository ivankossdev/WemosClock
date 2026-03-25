using System;
using ReactiveUI;

namespace WemosClock.ViewModels;

public partial class MainWindowViewModel : ReactiveObject
{
        private string _greeting = "Поиск устройств";
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        // Свойство, содержащее ViewModel для поиска
        public SearchViewModel SearchVM { get; } = new SearchViewModel();
}
