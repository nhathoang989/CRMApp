using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace HCRM.App.Views.Converters
{
    public class BoolToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value
                ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        private object NullableBooleanToFalse(object value)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                return value;
            }
        }
    }
}
