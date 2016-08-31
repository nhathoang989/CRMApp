using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCRM.WarehouseApp.Views.Converters
{
    public class YearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = this.NullYearToCurrentYear(value);
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = this.NullYearToCurrentYear(value);
            return result;
        }
        private object NullYearToCurrentYear(object value)
        {
            if (value == null)
            {
                value = DateTime.Now.Year;
            }
            return value;
        }
    }
}
