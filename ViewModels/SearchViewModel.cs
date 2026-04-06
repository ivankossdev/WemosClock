using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using WemosClock.Services; 
using Avalonia.Threading;

namespace WemosClock.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        private readonly IComportService _comportService;

        public SearchViewModel(IComportService comportService)
        {
            _comportService = comportService;
        } 

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
        /// Блокирует очистку списка пока идет поиск оборудования 
        /// </summary>
        private bool isBusy = false; 

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
                isBusy = true; 
                IsEnablad = false; 
                SearchDevices = $"Выбрано: {value}"; 
                _comportService.Init(value, 115200);
                _comportService.Open();
                // Подписка на событие получения данных
                _comportService.DataReceived += OnDataReceived;
                _comportService.Write("help");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void OnDataReceived(string data)
        {
            // Обновляем UI в потоке диспетчера
            Dispatcher.UIThread.Invoke(() =>
            {
                ResultText += data + "\n";
            });
        }

        /// <summary>
        /// Поиск подключенных устройств
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private void Search()
        {
            Devices.Clear();
            isBusy = true;
            IsEnablad = false; // если нужно блокировать кнопки

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
                isBusy = false;
                IsEnablad = true;
            }

        }
        
        /// <summary>
        /// Очищает список найденных устройств
        /// </summary>
        [RelayCommand]
        private void Clear()
        {
            if(!isBusy)
                Devices.Clear();
        }

        /// <summary>
        /// Возвращает к списку оборудования и очищает переменные
        /// </summary>
        [RelayCommand]
        private void ShowList()
        {
            IsListVisible = true;
            isBusy = false; 
            IsEnablad = true;
            SelectedDevice = null;
            ResultText = string.Empty;
            SearchDevices = "Найденные устройства";
            _comportService.Close();
            // Отписка от событий
            _comportService.DataReceived -= OnDataReceived;
        }

        [RelayCommand]
        private void GetIp()
        {
            ResultText = string.Empty;
            _comportService.Write("get ip");
        }
    }
}