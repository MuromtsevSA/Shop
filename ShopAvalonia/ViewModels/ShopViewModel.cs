using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopAvalonia.Model;
using ShopAvalonia.Services;
using System;
using System.Collections.ObjectModel;

namespace ShopAvalonia.ViewModels
{
    public partial class ShopViewModel : ObservableObject
    {
        private readonly ICartService _cartService;

        public ObservableCollection<Product> Products { get; } = new();

        public ShopViewModel(ICartService cartService)
        {
            _cartService = cartService;

            var command = new RelayCommand<Product>(AddToCart);

            
            Products.Add(new Product { Name = "Товар 1", Quantity = 10, ImageUrl = "https://via.placeholder.com/150", AddToCartCommand = command });
            Products.Add(new Product { Name = "Товар 2", Quantity = 5, ImageUrl = "https://via.placeholder.com/150", AddToCartCommand = command });

            Console.WriteLine("ShopViewModel initialized with AddToCartCommand: " + (AddToCartCommand != null));
        }

        [RelayCommand]
        private void AddToCart(Product product)
        {
            if (product == null || product.Quantity <= 0)
            {
                Console.WriteLine("Invalid product or out of stock.");
                return;
            }

            Console.WriteLine($"Adding {product.Name} to cart.");
            _cartService.AddToCartItem(product.Name);
            product.Quantity--;
        }
    }
}
