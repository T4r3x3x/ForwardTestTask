using Avalonia.Data;
using Avalonia.Data.Converters;

using ForwardTestTask.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace ForwardTestTask.Presentation.Converters
{
    public class NoteDtoConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values is null || values.Count != 3)
                throw new ArgumentNullException("Expected 3 parameters");

            var guid = values[0] as Guid?;
            var title = values[1] as string;
            var description = values[2] as string;

            ThrowExIfNull(guid);
            ThrowExIfNull(title);

            return new NoteDto(guid!.Value, title!, description!);

        }

        public object? ConvertBack(IList<object?> value, Type targetType, object? parameter, CultureInfo culture)
        {
            return BindingOperations.DoNothing;
        }

        private static void ThrowExIfNull(object? param)
        {
            if (param is null)
                throw new ArgumentNullException("Wrong param!");
        }
    }
}