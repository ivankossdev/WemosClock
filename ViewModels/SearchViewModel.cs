using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;

namespace WemosClock.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        readonly Random Rnd = new();
        /// <summary>
        /// Найденные устройства
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> _devices = [];

        /// <summary>
        /// управляет видимостью списка
        /// </summary>
        [ObservableProperty]
        private bool _isListVisible = true;  

        /// <summary>
        /// Количество найденных устройств
        /// </summary>
        private int count = 0; 

        /// <summary>
        /// Блокирует очистку списка пока идет поиск оборудования 
        /// </summary>
        private bool isBusy = false; 

        /// <summary>
        /// Делает актикной кнопку либо неактивной. 
        /// </summary>
        [ObservableProperty]
        private bool _isEnablad = true; 

        /// <summary>
        /// Управляет выбранным элементом
        /// </summary>
        [ObservableProperty]
        private string? _selectedDevice; 
        
        partial void  OnSelectedDeviceChanged(string? value)
        {
            if (value != null)
            {
                IsListVisible = false;
                isBusy = true; 
                IsEnablad = false; 
                Console.WriteLine($"Выбрано: {value}");
            }
        }

        [RelayCommand]
        private async Task Search()
        {
            Devices.Clear();
            isBusy = true; 
            count = 0;

            for (int i = 0; i < Rnd.Next(2, 50); i++)
            {
                await Task.Delay(Rnd.Next(100, 1500)); // имитация долгой операции
                Devices.Add($"[ {count += 1} ]\t" + DateTime.Now);
            }

            isBusy = false;
        }
        
        [RelayCommand]
        private void Clear()
        {
            if(!isBusy)
                Devices.Clear();
        }

        [RelayCommand]
        private void ShowList()
        {
            IsListVisible = true;
            isBusy = false; 
            IsEnablad = true;
        }

    }
}