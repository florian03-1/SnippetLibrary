using SnippetLibrary.Context;
using SnippetLibrary.ViewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.ViewModel.DialogViewModels.SpecialDialogs
{
    public class AboutDialogViewModel : ViewModelBase
    {
        public AboutDialogViewModel()
        {

        }

        public string AppName
        {
            get { return InfoContext.Instance.AppName; }
        }

        public string AppVersion
        {
            get { return InfoContext.Instance.AppVersion.ToString(); }
        }
        public string AppDescription
        {
            get { return InfoContext.Instance.AppDescription.ToString(); }
        }
        public string Copyright
        {
            get { return InfoContext.Instance.Copyright; }
        }
        public string LicenceName
        {
            get { return InfoContext.Instance.LicenceName; }
        }
        public string LicenceText
        {
            get { return InfoContext.Instance.LicenceText; }
        }

        public ObservableCollection<UsedLibrariesItem> AllUsedLibraries
        {
            get
            {
                ObservableCollection<UsedLibrariesItem> temp = new ObservableCollection<UsedLibrariesItem>();
                InfoContext.Instance.AllUsedLibraries.ForEach(x => temp.Add(x));
                return temp;
            }
        }

    }
}
