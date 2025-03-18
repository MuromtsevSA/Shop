using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using ShopAvalonia.ViewModels;

namespace ShopAvalonia.Views;

public partial class ProfileSettingView : UserControl
{
    public ProfileSettingView()
    {
        InitializeComponent();
    }

    private void TextBox_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is TextBox textBox && textBox.IsFocused)
        {
            
            if (this.Parent is IInputElement parentElement)
            {
                parentElement.Focus();
            }
        }
    }

    private void TextBox_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            if (textBox.IsFocused)
            {
                if (this.Parent is IInputElement parentElement)
                {
                    parentElement.Focus();
                }
            }
        }
    }
}