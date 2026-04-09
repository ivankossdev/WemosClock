using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using WemosClock.Services; 
using Avalonia.Threading;

namespace WemosClock.ViewModels
{
    public partial class SearchViewModel : ViewModelBase
    {
        private readonly IComportService _comportService;

        public SearchViewModel(IComportService comportService)
        {
            _comportService = comportService;
        } 

        [ObservableProperty]
        private string _greeting = "Поиск устройств";

        /// <summary>
        /// 
        /// </summary>
        [ObservableProperty]
        public string _searchDevices = "Найденные устройства"; 

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
        /// Делает активной кнопку либо неактивной. 
        /// </summary>
        [ObservableProperty]
        private bool _isEnablad = true; 

        /// <summary>
        /// Управляет выбранным элементом
        /// </summary>
        [ObservableProperty]
        private string? _selectedDevice; 

        [ObservableProperty]
        private string _resultText  = string.Empty;

        /// <summary>
        /// Обработчик нажатия на устройство
        /// </summary>
        /// <param name="value"></param>
        partial void  OnSelectedDeviceChanged(string? value)
        {
            if (value != null)
            {
                IsListVisible = false;
                IsEnablad = false; 
                SearchDevices = $"Выбрано: {value}"; 
            }
        }

        /// <summary>
        /// Поиск подключенных устройств
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private void Search()
        {
            Devices.Clear();
            IsEnablad = false; 

            try
            {
                var devices = _comportService.SearchDevices();
                foreach (var device in devices)
                {
                    Devices.Add(device);
                }
            }
            catch (Exception ex)
            {
                Devices.Add($"Ошибка: {ex.Message}");
            }
            finally
            {
                IsEnablad = true;
            }

        }
    }
    
}