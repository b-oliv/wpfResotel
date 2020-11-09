using System;
using System.Windows;
using System.Windows.Data;

namespace ProjetRESOTEL.Converters
{
    public class BoolToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null && value != DependencyProperty.UnsetValue && (bool)value ?
                new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red)
                : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
