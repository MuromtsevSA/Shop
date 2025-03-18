using Avalonia.Media.Imaging;
using Avalonia.Data.Converters;
using System;
using System.Globalization;
using Avalonia.Platform;

namespace ShopAvalonia.Converters
{
    public class BoolToImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isAvailable)
            {
                try
                {
                    var uri = isAvailable
                        ? "avares://ShopAvalonia/Assets/check.png"
                        : "avares://ShopAvalonia/Assets/check.png";
                    var bitmap = new Bitmap(AssetLoader.Open(new Uri(uri)));
                    return bitmap;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в конвертере: {ex.Message}");
                    return null; 
                }
            }

            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
