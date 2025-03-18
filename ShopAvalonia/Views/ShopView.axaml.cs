using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Diagnostics;

namespace ShopAvalonia.Views;

public partial class ShopView : UserControl
{
    public ShopView()
    {
        InitializeComponent();

        this.DataContextChanged += (s, e) =>
        {
            Debug.WriteLine($"DataContext for ShopView changed: {this.DataContext?.GetType().Name ?? "null"}");
        };
    }
}