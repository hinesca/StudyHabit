using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StudyHabit
{
     public class BoolToVisibilityConverter : IValueConverter
     {
          public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
          {
               if (!(value is bool))
                    return Visibility.Collapsed;

               if ((bool)value)
                    return Visibility.Visible;
               else return Visibility.Collapsed;
          }

          public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
          {
               if (value.Equals(Visibility.Visible))
                    return true;
               else return false;
          }
     }
}