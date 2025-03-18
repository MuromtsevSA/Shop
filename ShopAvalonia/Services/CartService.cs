using ShopAvalonia.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopAvalonia.Services
{
    public class CartService : ICartService
    {
        private readonly ObservableCollection<CartItem> _items = new();
        public ReadOnlyObservableCollection<CartItem> Items { get; }

        public CartService()
        {
            Items = new ReadOnlyObservableCollection<CartItem>(_items);

            //_items.Add(new CartItem { ProductName = "Яблоко", Quantity = 3 });
            //_items.Add(new CartItem { ProductName = "Банан", Quantity = 5 });
            //_items.Add(new CartItem { ProductName = "Груша", Quantity = 2 });
        }

        public void AddToCartItem(string productName)
        {
            var existingItem = _items.FirstOrDefault(item => item.ProductName == productName);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _items.Add(new CartItem { ProductName = productName, Quantity = 1 });
            }

            UpdateIndices();
        }

        public int TotalItems => _items.Sum(item => item.Quantity);

        private void UpdateIndices()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Index = i + 1; // Нумерация начинается с 1
            }
        }
    }
}
