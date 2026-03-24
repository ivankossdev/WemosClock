using System;

namespace WemosClock.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Поиск устройств";
    private string _resultText = "Результат\n";

    public string ResultText
    {
        get => _resultText;
        set
        {
            _resultText = value;
            OnPropertyChanged();
        }
    }

    public void Search()
    {
        ResultText += "Найдено устройство: " + DateTime.Now + "\n";
    }
}
