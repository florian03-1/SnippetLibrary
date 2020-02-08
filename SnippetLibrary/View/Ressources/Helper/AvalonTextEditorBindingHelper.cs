using ICSharpCode.AvalonEdit;
using System;
using System.Linq;
using System.Windows;

namespace SnippetLibrary.View.Ressources.Helper
{
    public class AvalonTextEditorBindingHelper
    {
        public static string GetSnippetText(TextEditor obj)
        {
            return (string)obj.GetValue(SnippetTextProperty);
        }

        public static void SetSnippetText(DependencyObject obj, string value)
        {
            obj.SetValue(SnippetTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for SnippetText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SnippetTextProperty =
            DependencyProperty.RegisterAttached("SnippetText", typeof(string), typeof(AvalonTextEditorBindingHelper), new PropertyMetadata(string.Empty, SnippetTextProperty_Changed));

        private static void SnippetTextProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // DANKE - @MichaHo von vb-Paradise.de
            var textEditor = (TextEditor)d;
            textEditor.TextChanged -= SnippetText_Changed;
            textEditor.TextChanged += SnippetText_Changed;
            if (textEditor.Document != null)
            {
                var caretOffset = textEditor.CaretOffset;
                textEditor.Document.Text = e.NewValue is null ? string.Empty : e.NewValue as string;
                textEditor.CaretOffset = Math.Min(caretOffset, (e.NewValue as string).Length);
            }
        }


        private static void SnippetText_Changed(object sender, EventArgs e)
        {
            TextEditor editor = (TextEditor)sender;
            editor.SetValue(SnippetTextProperty, editor.Document.Text);
        }
    }
}
