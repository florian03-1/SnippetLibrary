using SnippetLibrary.ViewModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SnippetLibrary.ViewModel.DialogViewModels.SpecialDialogs
{
    public class ErrorDialogViewModel : ViewModelBase
    {

        public ErrorDialogViewModel()
        {
            if (IsInDesignMode)
            {
                ErrorText = "Die Datei konnte nicht geäffnet.";
                ex = new ArgumentException();
            }
        }

        public ErrorDialogViewModel(string errorMessage, Exception ex)
        {
            _ErrorText = errorMessage;
            this.ex = ex;
        }

        private string _ErrorText;

        public string ErrorText
        {
            get { return _ErrorText; }
            set { _ErrorText = value; RaisePropertyChanged(); }
        }

        public string ErrorMessage
        {
            get { return ex.Message + "\n" + ex.StackTrace; }
        }


        private Exception ex;





        private ICommand _Close;
        public ICommand CloseCommand
        {
            get
            {
                if (_Close == null)
                {
                    _Close = new RelayCommand(x => Environment.Exit(0));
                }
                return _Close;
            }
        }

        private ICommand _Mail;
        public ICommand MailCommand
        {
            get
            {
                if (_Mail == null)
                {
                    _Mail = new RelayCommand(x => Process.Start("mailto:florian.programming@gmail.com?subject=SnippetLibrary Error&body=" + ex.Message + "\n\n" + ex.StackTrace));
                }
                return _Mail;
            }
        }
    }
}
