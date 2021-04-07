using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Taskick.Services
{
    public class NegateBooleanConverter : IValueConverter // Used to inverse boolean values in xaml
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
