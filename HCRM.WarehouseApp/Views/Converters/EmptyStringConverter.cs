using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCRM.WarehouseApp.Views.Converters
{
    public class EmptyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = this.EmptyStringToNull(value);
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = this.EmptyStringToNull(value);
            return result;
        }
        private object EmptyStringToNull(object value)
        {
            string stringValue = (string)value;
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }
            return value;
        }
    }
}
