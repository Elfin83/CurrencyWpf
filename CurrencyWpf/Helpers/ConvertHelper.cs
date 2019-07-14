using System;
using System.Windows.Data;

namespace CurrencyWpf.Helpers
{
    [ValueConversion(typeof(decimal), typeof(string))]
    public class CostConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return ((decimal)value).ToString("#,###.0000", culture) + " руб.";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            decimal result;
            if (Decimal.TryParse(value.ToString(), System.Globalization.NumberStyles.Any,
                         culture, out result))
            {
                return result;
            }
            else if (Decimal.TryParse(value.ToString().Replace(" руб.", ""), System.Globalization.NumberStyles.Any,
                         culture, out result))
            {
                return result;
            }
            return value;
        }
    }
    [ValueConversion(typeof(DateTime), typeof(string))]
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            DateTime result;
            if (DateTime.TryParse(value.ToString(), out  result))
            {
                return result;
            }           
            return value;
        }
    }
}
