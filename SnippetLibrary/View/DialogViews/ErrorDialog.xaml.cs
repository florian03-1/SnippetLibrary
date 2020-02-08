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
    /// Interaktionslogik für ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : Window
    {
        ErrorDialogViewModel Vm { get; set; }

        public ErrorDialog()
        {
            InitializeComponent();
        }

        public ErrorDialog(ErrorDialogViewModel vm)
        {
            Vm = vm;
            DataContext = Vm;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
