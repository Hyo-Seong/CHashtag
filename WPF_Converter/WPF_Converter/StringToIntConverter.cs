// StringToIntConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_Converter
{
    public class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ViewModel ->  View의 경우 기본값 그대로 return 하도록 한다.
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = 0;

            Int32.TryParse((string)value, out result);

            return result;
        }
    }
}
