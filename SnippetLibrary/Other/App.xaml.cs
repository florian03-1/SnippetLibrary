using SnippetLibrary.View.WorkspaceViews;
using SnippetLibrary.ViewModel.WorkspaceViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SnippetLibrary
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWorkspaceViewModel vm = new MainWorkspaceViewModel();
            win_mainWorkspace win = new win_mainWorkspace(vm);
            win.Show();

        }
    }
}
