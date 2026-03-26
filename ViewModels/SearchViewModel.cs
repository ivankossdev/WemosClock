using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;

namespace WemosClock.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _newResultText  = "Результат\n";

        private int count = 0; 

        [RelayCommand]
        private async Task Search()
        {
            NewResultText = "Результат\n";

            Random rnd = new();
            for (int i = 0; i < rnd.Next(2, 50); i++)
            {
                await Task.Delay(rnd.Next(100, 1500)); // имитация долгой операции
                NewResultText += $"Найдено устройство: {count += 1}\t" + DateTime.Now + "\n";
            }

            NewResultText += "Поиск завершен.\n";
            count = 0;
        }
        
    }
}