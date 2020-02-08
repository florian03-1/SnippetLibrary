using SnippetLibrary.Model;
using SnippetLibrary.ViewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.ModelViewModels
{
    public class SnippetEnitryViewModel : ViewModelBase
    {
        public SnippetEnitry SnippetEnitry_Model { get; set; }
        public SnippetEnitryViewModel(SnippetEnitry model, List<LanguageViewModel> aviableDatas)
        {
            SnippetEnitry_Model = model;
          
            AviableLanguages = aviableDatas;
            _Language = aviableDatas.Where(x => x.ID == model.LanguageID).SingleOrDefault();
        }


        public List<LanguageViewModel> AviableLanguages { get; }

        private LanguageViewModel _Language;
        public LanguageViewModel Language
        {
            get { return _Language; }
            set { _Language = value; SnippetEnitry_Model.LanguageID = value.ID; RaisePropertyChanged(); }
        }


        public string Name
        {
            get { return SnippetEnitry_Model.Name; }
            set { SnippetEnitry_Model.Name = value; RaisePropertyChanged(); }
        }

        public string SnippetText
        {
            get { return SnippetEnitry_Model.SnippetText; }
            set { SnippetEnitry_Model.SnippetText = value; RaisePropertyChanged(); }
        }


    }

}
