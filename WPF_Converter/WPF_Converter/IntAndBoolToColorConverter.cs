// IntAndBoolToColorConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF_Converter
{
    public class IntAndBoolToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Transparent);

            if (values == null)
            {
                return color;
            }

            int personCount = (int)values[0];

            bool isSecond = (bool)values[1];

            // 거리두기 2단계 이상일 때에는 5인 이상 집합 금지!
            if (isSecond && personCount >= 5)
            {
                color = new SolidColorBrush(Colors.Red);
            }

            return color;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
