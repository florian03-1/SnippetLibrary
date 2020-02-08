using SnippetLibrary.Context;
using SnippetLibrary.ViewModel.Infrastructure;
using SnippetLibrary.ViewModel.ModelViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.DialogViewModels
{
    public class AddSnippetDialogViewModel : ViewModelBase
    {
        public AddSnippetDialogViewModel()
        {
            List<LanguageViewModel> lVM = new List<LanguageViewModel>(); DataContext.Instance.Languages.ForEach(x => lVM.Add(new LanguageViewModel(x)));
            Model.Snippet sModel = new Model.Snippet(); sModel.Name = ""; sModel.LanguageID = lVM.FirstOrDefault().ID;
            sModel.SnippetEnitries = new List<Model.SnippetEnitry>();
            Snippet = new SnippetViewModel(sModel, lVM);
        }

        private SnippetViewModel _Snippet;
        public SnippetViewModel Snippet
        {
            get { return _Snippet; }
            set { _Snippet = value; RaisePropertyChanged(); }
        }


        public void Add()
        {
            DataContext.Instance.Snippets.Add(Snippet.Snippet_Model);
        }

    }
}
