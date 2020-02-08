using SnippetLibrary.ViewModel.DialogViewModels.SpecialDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnippetLibrary.View.DialogViews
{
    /// <summary>
    /// Interaktionslogik für HelpDialog.xaml
    /// </summary>
    public partial class HelpDialog : Window
    {
        

        public HelpDialog(HelpViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void Ok_Execute(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
