using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using ShopAvalonia.ViewModels;
using ShopAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using ShopAvalonia.Services;
using System;

namespace ShopAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
           
            var services = new ServiceCollection();
            ConfigureServices(services); 
            var serviceProvider = services.BuildServiceProvider();

           
            var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();

            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

           
            var mainViewModel = serviceProvider.GetRequiredService<MainViewModel>();

            singleViewPlatform.MainView = new MainView
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void ConfigureServices(IServiceCollection services)
    {

        services.AddSingleton<ICartService, CartService>();


        services.AddSingleton<MainViewModel>();
        services.AddTransient<MenuViewModel>();
        services.AddTransient<HeaderViewModel>();
        services.AddSingleton<ShopViewModel>();
        services.AddSingleton<CartViewModel>();
        services.AddSingleton<SettingsViewModel>();

        services.AddTransient<MainWindow>();
        services.AddTransient<MenuView>();
        services.AddTransient<HeaderView>();
        services.AddTransient<ShopView>(); 
        services.AddTransient<CartView>();
        services.AddTransient<ProfileSettingView>();

        services.AddSingleton<Func<ShopView>>(provider => () =>
        {
            var view = provider.GetRequiredService<ShopView>();
            view.DataContext = provider.GetRequiredService<ShopViewModel>();
            return view;
        });
        services.AddSingleton<Func<CartView>>(provider => () =>
        {
            var view = provider.GetRequiredService<CartView>();
            view.DataContext = provider.GetRequiredService<CartViewModel>();
            return view;
        });
        services.AddSingleton<Func<ProfileSettingView>>(provider => () =>
        {
            var view = provider.GetRequiredService<ProfileSettingView>();
            view.DataContext = provider.GetRequiredService<SettingsViewModel>();
            return view;
        });
        //services.AddSingleton<Func<CartView>>(provider => () => provider.GetRequiredService<CartView>());

    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}