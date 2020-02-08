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
    /// Interaktionslogik für win_manageLanguagesDialog.xaml
    /// </summary>
    public partial class win_manageLanguagesDialog : Window
    {
        public ManageLanguagesDialogViewModel Vm { get; set; }
        public win_manageLanguagesDialog()
        {
            InitializeComponent();
        }
        public win_manageLanguagesDialog(ManageLanguagesDialogViewModel vm)
        {
            Vm = vm;
            DataContext = Vm;
            InitializeComponent();
        }

        private void Ok_Execute(object sender, RoutedEventArgs e)
        {
            Vm.Save();
            DialogResult = true;
            Close();
        }

        private void Cancel_Execute(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
