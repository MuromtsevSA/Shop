using CommunityToolkit.Mvvm.ComponentModel;
using ShopAvalonia.Model;
using ShopAvalonia.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopAvalonia.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly ICartService _cartService;

        public ReadOnlyObservableCollection<CartItem> Items => _cartService.Items;

        public CartViewModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public int UniqueItemsCount => Items.Count;

        public int TotalQuantity => _cartService.TotalItems;
    }
}
