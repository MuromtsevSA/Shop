using CommunityToolkit.Mvvm.ComponentModel;

namespace ShopAvalonia.Model
{
    public partial class CartItem : ObservableObject
    {
        [ObservableProperty]
        public int _index;

        [ObservableProperty]
        private string _productName = string.Empty;

        [ObservableProperty]
        private int _quantity;

        public bool IsAvailable => _quantity > 0;
    }
}
