using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SnippetLibrary.View.Ressources.Converter
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Konvertiert einen Boolean in eine Visibility Eigenschaft
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter">reverse</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                if (parameter?.ToString().ToLower() == "reverse") return Visibility.Collapsed;
                else return Visibility.Visible;
            }
            else
            {
                if (parameter?.ToString().ToLower() == "reverse") return Visibility.Visible;
                else return Visibility.Collapsed;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
