using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;

namespace WemosClock.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> _devices = [];
        private int count = 0; 
        private bool isSearch = false; 

        [RelayCommand]
        private async Task Search()
        {
            Devices.Clear();
            isSearch = true; 

            Random rnd = new();
            for (int i = 0; i < rnd.Next(2, 50); i++)
            {
                
                await Task.Delay(rnd.Next(100, 1500)); // имитация долгой операции
                
                Devices.Add($"[ {count += 1} ]\t" + DateTime.Now);
            }
            count = 0;

            isSearch = false;
        }
        
        [RelayCommand]
        private void Clear()
        {
            if(!isSearch)
                Devices.Clear();
        }
    }
}