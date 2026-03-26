using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WemosClock.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _newResultText  = "Результат\n";

        [RelayCommand]
        private void Search()
        {
            NewResultText += "Найдено устройство: " + DateTime.Now + "\n";
        }
    }
}