using ShopAvalonia.Model;
using System.Collections.ObjectModel;

namespace ShopAvalonia.Services
{
    public interface ICartService
    {
        ReadOnlyObservableCollection<CartItem> Items { get; }
        int TotalItems { get; }
        void AddToCartItem(string productName);
    }
}
