using SnippetLibrary.ViewModel.WorkspaceViewModels;
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

namespace SnippetLibrary.View.WorkspaceViews
{
    /// <summary>
    /// Interaktionslogik für win_mainWorkspace.xaml
    /// </summary>
    public partial class win_mainWorkspace : Window
    {

        MainWorkspaceViewModel Vm { get; set; }

        public win_mainWorkspace()
        {
            InitializeComponent();
        }

        public win_mainWorkspace(MainWorkspaceViewModel vm)
        {
            Vm = vm;
            DataContext = Vm;
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
