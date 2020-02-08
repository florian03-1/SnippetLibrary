using SnippetLibrary.Context;
using SnippetLibrary.Model;
using SnippetLibrary.ViewModel.Infrastructure;
using SnippetLibrary.ViewModel.ModelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace SnippetLibrary.ViewModel.DialogViewModels
{
    public class EditSnippetDialogViewModel : ViewModelBase
    {

        public EditSnippetDialogViewModel(Guid snippetID)
        {
            Snippet sn = (Snippet) DataContext.Instance.Snippets.FirstOrDefault(x => x.ID == snippetID).Clone();  //Damit nicht nur die Instanz übergeben wird
            List<LanguageViewModel> lVM = new List<LanguageViewModel>();
            DataContext.Instance.Languages.ForEach(x => lVM.Add(new LanguageViewModel(x)));
            Snippet = new SnippetViewModel(sn, lVM);
        }

        private SnippetViewModel _Snippet;
        public SnippetViewModel Snippet
        {
            get { return _Snippet; }
            set { _Snippet = value; RaisePropertyChanged(); }
        }


        #region Methoden

        public void Save()
        {
            DataContext.Instance.Snippets.RemoveAll(x => x.ID == Snippet.ID);
            Snippet.UpdateModel();
            DataContext.Instance.Snippets.Add(Snippet.Snippet_Model);
        }


        private void RemoveSelectedSnippetEnitry()
        {
            if (Xceed.Wpf.Toolkit.MessageBox.Show("Wollen sie den Snippet Eintrag wirklich löschen?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Snippet.SnippetEnitries.Remove(Snippet.SelectedSnippetEnitry);
                Snippet.SelectedSnippetEnitry = Snippet.SnippetEnitries.FirstOrDefault();
            }
        }

        private void AddSnippetEnitry()
        {
            SnippetEnitryViewModel newEnitry = new SnippetEnitryViewModel(new SnippetEnitry(), Snippet.AviableLanguages);
            newEnitry.Language = Snippet.Language;
            newEnitry.Name = "[NeuesSnippet]";
            newEnitry.SnippetText = " ";  //Damit es nicht zu dem Fehler kommt
            Snippet.SnippetEnitries.Add(newEnitry);
            Snippet.SelectedSnippetEnitry = Snippet.SnippetEnitries.FirstOrDefault(x => x.Equals(newEnitry));
        }

        #endregion


        private ICommand _RemoveSelectedSnippetEnitry;
        public ICommand RemoveSelectedSnippetEnitryCommand
        {
            get
            {
                if (_RemoveSelectedSnippetEnitry == null)
                {
                    _RemoveSelectedSnippetEnitry = new RelayCommand(x => RemoveSelectedSnippetEnitry(), x => Snippet.SelectedSnippetEnitry != null);
                }
                return _RemoveSelectedSnippetEnitry;
            }
        }

        private ICommand _AddSnippetEnitry;
        public ICommand AddSnippetEnitryCommand
        {
            get
            {
                if (_AddSnippetEnitry == null)
                {
                    _AddSnippetEnitry = new RelayCommand(x => AddSnippetEnitry());
                }
                return _AddSnippetEnitry;
            }
        }

    }
}
