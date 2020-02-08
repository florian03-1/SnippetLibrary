using SnippetLibrary.ViewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.DialogViewModels.SpecialDialogs
{
    public class HelpViewModel : ViewModelBase
    {

        public HelpViewModel(string helpTitle, string helpText)
        {
            HelpTitle = helpTitle;
            HelpText = helpText;
        }

        private string _HelpTitle;

        public string HelpTitle
        {
            get { return _HelpTitle; }
            set { _HelpTitle = value; RaisePropertyChanged(); }
        }

        private string _HelpText;

        public string HelpText
        {
            get { return _HelpText; }
            set { _HelpText = value; RaisePropertyChanged(); }
        }


    }
}
