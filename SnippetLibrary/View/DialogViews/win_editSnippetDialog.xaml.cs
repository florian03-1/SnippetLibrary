using SnippetLibrary.ViewModel.DialogViewModels;
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
    /// Interaktionslogik für win_editSnippet.xaml
    /// </summary>
    public partial class win_editSnippetDialog : Window
    {
        public EditSnippetDialogViewModel Vm { get; set; }

        public win_editSnippetDialog()
        {
            InitializeComponent();
        }

        public win_editSnippetDialog(EditSnippetDialogViewModel vm)
        {
            Vm = vm;
            DataContext = Vm;
            InitializeComponent();
        }

        public void Save_Execute(object sender, RoutedEventArgs e)
        {
            Vm.Save();
            DialogResult = true;
            Close();
        }
        public void Cancel_Execute(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
