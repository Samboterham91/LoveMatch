using System;
using Microsoft.Maui.Controls;

namespace LoveMatch.Converters
{
    public class BoolToLikeTextConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool liked)
                return liked ? "Liked!" : "❤️ Like";
            return "❤️ Like";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}