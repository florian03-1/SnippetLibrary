using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SnippetLibrary.View.Ressources.Converter
{
    public class StringToAvalonSyntaxHighlightingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICSharpCode.AvalonEdit.Highlighting.IHighlightingDefinition definition = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition((string)value);

            if ((string) value == "XAML")
            {
                definition = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("XML");
            }

            if (definition != null)
            {
                return definition;
            }
            else { 
                return null; 
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
