using System;
using System.Reflection;
using System.Windows.Data;

namespace HCRM.App.Views.Converters
{
    public class DisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PropertyInfo propInfo = value.GetType().GetProperty(parameter.ToString());
            var attrib = propInfo.GetCustomAttributes(typeof(System.ComponentModel.DisplayNameAttribute), false);

            if (attrib.Length > 0)
            {
                return ((System.ComponentModel.DisplayNameAttribute)attrib[0]).DisplayName;
            }

            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
