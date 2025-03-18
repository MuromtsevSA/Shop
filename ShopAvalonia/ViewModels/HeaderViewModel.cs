using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAvalonia.ViewModels
{
    public partial class HeaderViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _currentPageTitle = "Главная";
    }
}
