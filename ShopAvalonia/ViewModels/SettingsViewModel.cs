using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Text.RegularExpressions;

namespace ShopAvalonia.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string lastName = "Иванов";

        [ObservableProperty]
        private string firstName = "Иван";

        [ObservableProperty]
        private string middleName = "Иванович"; 

        [ObservableProperty]
        private string age = "30";

        [ObservableProperty]
        private string fullName = "Иванов Иван Иванович";

        [ObservableProperty]
        private string phone = "+79111234567";

        [ObservableProperty]
        private string email = "ivanov@example.com";

        [ObservableProperty]
        private string balance = "1000.00";

        [ObservableProperty]
        private bool isEditing = true;

        [ObservableProperty]
        private bool isFocused = false;

        [RelayCommand]
        private void ToggleEditMode()
        {
            IsEditing = !IsEditing;

            if (!IsEditing)
            {
                IsFocused = false;
            }
        }

        

        partial void OnPhoneChanging(string value)
        {
            if (!Regex.IsMatch(value, @"^\+?\d{10,15}$"))
            {
                throw new ArgumentException("Неверный формат телефона!");
            }
        }

        partial void OnEmailChanging(string value)
        {
            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new ArgumentException("Неверный формат email!");
            }
        }
    }
}
