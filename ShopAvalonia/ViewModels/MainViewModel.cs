using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using ShopAvalonia.Views;
using System;

namespace ShopAvalonia.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private Control _currentPage;

    public MenuViewModel MenuViewModel { get; }
    public HeaderViewModel HeaderViewModel { get; }

    private readonly Func<ShopView> _shopViewFactory;
    private readonly Func<CartView> _CartItemViewFactory;
    private readonly Func<ProfileSettingView> _profileSettingViewFactory;

    public MainViewModel(
        MenuViewModel menuViewModel,
        HeaderViewModel headerViewModel,
        Func<ShopView> shopViewFactory,
        Func<CartView> CartItemViewFactory, Func<ProfileSettingView> ProfileSettingViewFactory)
    {
        MenuViewModel = menuViewModel;
        HeaderViewModel = headerViewModel;

        _shopViewFactory = shopViewFactory;
        _CartItemViewFactory = CartItemViewFactory;
        _profileSettingViewFactory = ProfileSettingViewFactory;

        MenuViewModel.NavigationRequested += OnNavigationRequested;

        CurrentPage = new TextBlock
        {
            Text = "Добро пожаловать!",
            FontSize = 24,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };

        HeaderViewModel.CurrentPageTitle = "Главная";
    }

    private void OnNavigationRequested(string pageTag)
    {
        switch (pageTag)
        {
            case "Shop":
                CurrentPage = _shopViewFactory();
                HeaderViewModel.CurrentPageTitle = "Магазин";
                break;

            case "Cart":
                CurrentPage = _CartItemViewFactory();
                HeaderViewModel.CurrentPageTitle = "Корзина";
                break;

            case "Settings":
   
                CurrentPage = _profileSettingViewFactory();
                HeaderViewModel.CurrentPageTitle = "Настройки";
                break;

            default:
                CurrentPage = new TextBlock
                {
                    Text = "Страница не найдена",
                    FontSize = 24,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
                };
                HeaderViewModel.CurrentPageTitle = "Неизвестная";
                break;
        }
    }
}
