using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCRM.WarehouseApp.Views.Converters
{
    public class FilePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = this.GetFullPath(value);
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            object result = this.GetFullPath(value);
            return result;
        }
        private object GetFullPath(object value)
        {
            string stringValue = (string)value;
            if (string.IsNullOrEmpty(stringValue))
            {
                return null;
            }
            object result = (object)Path.Combine(AppDomain.CurrentDomain.BaseDirectory, stringValue);
            return result;
        }
    }
}
