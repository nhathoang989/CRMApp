using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCRM.App.Views.Converters
{
    public class NullableBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            object result = this.NullableBooleanToFalse(value);
            return result;
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            object result = this.NullableBooleanToFalse(value);
            return result;
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
