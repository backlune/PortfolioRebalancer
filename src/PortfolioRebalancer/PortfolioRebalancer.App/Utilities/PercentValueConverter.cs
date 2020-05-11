using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace PortfolioRebalancer.App.Utilities
{
    public class PercentValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal)
            {
                return ((decimal)value * 100).ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;
            if (stringValue != null)
            {
                if (Decimal.TryParse(stringValue, out decimal actual))
                {
                    return actual == 0 ? 0 : actual / 100;
                }
            }

            return value;
        }
    }
}
