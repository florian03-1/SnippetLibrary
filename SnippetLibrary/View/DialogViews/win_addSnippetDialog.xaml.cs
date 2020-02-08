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
using SnippetLibrary.ViewModel.DialogViewModels;

namespace SnippetLibrary.View.DialogViews
{
    /// <summary>
    /// Interaktionslogik für win_addSnippetDialog.xaml
    /// </summary>
    public partial class win_addSnippetDialog : Window
    {

        public AddSnippetDialogViewModel Vm { get; set; }

        public win_addSnippetDialog()
        {
            InitializeComponent();
        }

        public win_addSnippetDialog(AddSnippetDialogViewModel vm)
        {
            Vm = vm;
            DataContext = Vm;
            InitializeComponent();
        }



        public void AddSnippet_Execute(object sender, RoutedEventArgs e)
        {
            Vm.Add();
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
