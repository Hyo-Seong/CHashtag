// OddOrEvenConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_ComboBox_Converter
{
    public class OddOrEvenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int input = (int)value;

            if(input%2 == 0)
            {
                return  $"{input} - 짝수";
            } 
            else
            {
                return $"{input} - 홀수";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 이번 프로그램에서는 ViewModel -> View로의 Convert만 이루어지기 때문에 ConvertBack은 구현하지 않아도 됩니다.
            throw new NotImplementedException();
        }
    }
}
