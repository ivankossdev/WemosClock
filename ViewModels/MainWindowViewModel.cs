namespace WemosClock.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Поиск устройств";

    public void Search()
    {
        System.Console.WriteLine("Press button");
    }
}
