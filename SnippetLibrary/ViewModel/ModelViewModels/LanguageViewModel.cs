using SnippetLibrary.Context;
using SnippetLibrary.Model;
using SnippetLibrary.ViewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.ModelViewModels
{
    public class LanguageViewModel : ViewModelBase
    {
        public Language Language_Model { get; set; }
        public LanguageViewModel(Language model)
        {
            Language_Model = model;
        }

        public Guid ID
        {
            get { return Language_Model.ID; }
        }


        public string Name
        {
            get { return Language_Model.Name; }
            set { Language_Model.Name = value; RaisePropertyChanged(); }
        }

        public int UseCount
        {
            get
            {
                int usecount = 0;
                foreach (Snippet s in DataContext.Instance.Snippets)
                {
                    if (s.LanguageID == ID) usecount++;
                    foreach (SnippetEnitry enitry in s.SnippetEnitries)
                    {
                        if (enitry.LanguageID == ID) usecount++;
                    }
                }
                return usecount;

            }
        }
    }
}
