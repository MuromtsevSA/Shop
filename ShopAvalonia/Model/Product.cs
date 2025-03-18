using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAvalonia.Model
{
    public partial class Product : ObservableObject
    {
        public IRelayCommand AddToCartCommand { get; set; }

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private int _quantity;

        [ObservableProperty]
        private string _imageUrl = string.Empty;

 
    }
}
