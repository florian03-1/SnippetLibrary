using SnippetLibrary.Model;
using SnippetLibrary.ViewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.ModelViewModels
{
    public class SnippetViewModel : ViewModelBase, ICloneable
    {
        public Snippet Snippet_Model { get; set; }
        public SnippetViewModel(Snippet model, List<LanguageViewModel> aviableDatas)
        {
            SnippetEnitries = new ObservableCollection<SnippetEnitryViewModel>();

            Snippet_Model = model;           

            model.SnippetEnitries.ForEach(x => SnippetEnitries.Add(new SnippetEnitryViewModel(x, aviableDatas)));

            AviableLanguages = aviableDatas;
            Language = AviableLanguages.Where(x => x.ID == model.LanguageID).SingleOrDefault();

            SelectedSnippetEnitry = SnippetEnitries.FirstOrDefault();

        }

        public Guid ID
        {
            get { return Snippet_Model.ID; }
        }


        private ObservableCollection<SnippetEnitryViewModel> _SnippetEnitries;
        public ObservableCollection<SnippetEnitryViewModel> SnippetEnitries
        {
            get { return _SnippetEnitries; }
            set
            {
                _SnippetEnitries = value;
                UpdateModel();
                RaisePropertyChanged();
            }
        }

        private SnippetEnitryViewModel _SelectedSnippetEnitry;
        public SnippetEnitryViewModel SelectedSnippetEnitry
        {
            get { return _SelectedSnippetEnitry; }
            set { _SelectedSnippetEnitry = value; RaisePropertyChanged(); }
        }




        public string Tags
        {
            get { return Snippet_Model.Tags; }
            set { Snippet_Model.Tags = value; RaisePropertyChanged(); }
        }






        public List<LanguageViewModel> AviableLanguages { get; }
        private LanguageViewModel _Language;
        public LanguageViewModel Language
        {
            get { return _Language; }
            set { _Language = value; Snippet_Model.LanguageID = value.ID; RaisePropertyChanged(); }
        }

        public string Name
        {
            get { return Snippet_Model.Name; }
            set { Snippet_Model.Name = value; RaisePropertyChanged(); }
        }



        public DateTime CreatedAt
        {
            get { return Snippet_Model.CreatedAt; }
            set { Snippet_Model.CreatedAt = value; RaisePropertyChanged(); }
        }

        public string CreatedBy
        {
            get { return Snippet_Model.CreatedBy; }
            set {  Snippet_Model.CreatedBy = value; RaisePropertyChanged(); }
        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void UpdateModel()
        {
            if (Snippet_Model != null)
            {
                Snippet_Model.SnippetEnitries.Clear();
                _SnippetEnitries.ToList().ForEach(x => Snippet_Model.SnippetEnitries.Add(x.SnippetEnitry_Model));
            }
        }
    }
}
