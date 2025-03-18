using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace ShopAvalonia.Converters
{
    public class BoolToWidthConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isExpanded)
            {
                // Возвращаем GridLength с фиксированной шириной
                return isExpanded ? new GridLength(200) : new GridLength(60);
            }

            // Значение по умолчанию
            return new GridLength(50);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
