using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Reactive;

namespace WemosClock.ViewModels
{
    public class SearchViewModel : ReactiveObject
    {
        private string _resultText = "Результат\n";
        public string ResultText
        {
            get => _resultText;
            set => this.RaiseAndSetIfChanged(ref _resultText, value);
        }

        public ReactiveCommand<Unit, Unit> SearchCommand { get; }

        public SearchViewModel()
        {
            SearchCommand = ReactiveCommand.Create(Search, outputScheduler: AvaloniaScheduler.Instance);
        }

        private void Search()
        {
            ResultText += "Найдено устройство: " + DateTime.Now + "\n";
        }
    }
}