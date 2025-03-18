using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace ShopAvalonia.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isMenuExpanded = true;

        // Событие для передачи команды навигации в MainViewModel
        public event Action<string>? NavigationRequested;

        // Команда для переключения состояния меню
        [RelayCommand]
        private void ToggleMenu()
        {
            IsMenuExpanded = !IsMenuExpanded;
        }

        // Команда для навигации
        [RelayCommand]
        private void Navigate(string pageTag)
        {
            NavigationRequested?.Invoke(pageTag);
        }
    }
}
