using Avalonia.Data.Converters;

using System;
using System.Globalization;

namespace ForwardTestTask.Presentation.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            var date = value as DateTime?;
            return date.HasValue == false ? "the note haven't edited" : date.Value.ToString("dd/MM/yyyy");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}