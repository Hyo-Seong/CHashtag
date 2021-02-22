// IntToColorConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_Converter
{
    public class IntToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);
            if(value == null)
            {
                return color;
            }
            int personCount = (int)value;

            // 5인 이상 집합 금지!
            if (personCount >= 5)
            {
                color = new SolidColorBrush(Colors.Red);
            }
             
            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
