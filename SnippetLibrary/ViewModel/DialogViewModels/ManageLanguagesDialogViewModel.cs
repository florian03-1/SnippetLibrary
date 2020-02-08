using SnippetLibrary.Context;
using SnippetLibrary.ViewModel.Infrastructure;
using SnippetLibrary.ViewModel.ModelViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnippetLibrary.Model;
using System.Windows.Input;
using SnippetLibrary.ViewModel.DialogViewModels.SpecialDialogs;
using SnippetLibrary.View.DialogViews;

namespace SnippetLibrary.ViewModel.DialogViewModels
{
    public class ManageLanguagesDialogViewModel : ViewModelBase
    {

        public ManageLanguagesDialogViewModel()
        {
            if (!IsInDesignMode == true)
            {
                Languages = new ObservableCollection<LanguageViewModel>();
                DataContext.Instance.Languages.ForEach(x => Languages.Add(new LanguageViewModel(x)));
                SelectedLanguage = Languages.FirstOrDefault();
            }
        }



        private LanguageViewModel _SelectedLanguage;

        public LanguageViewModel SelectedLanguage
        {
            get { return _SelectedLanguage; }
            set { _SelectedLanguage = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<LanguageViewModel> _Languages;

        public ObservableCollection<LanguageViewModel> Languages
        {
            get { return _Languages; }
            set { _Languages = value; RaisePropertyChanged(); }
        }


        private void NewLanguage()
        {
            Language Language = new Language(); Language.Name = "[Neue Sprache]";
            LanguageViewModel newLanguage = new LanguageViewModel(Language);
            Languages.Add(newLanguage);
            SelectedLanguage = newLanguage;
        }




        private ICommand _NewLanguage;
        public ICommand NewLanguageCommand
        {
            get
            {
                if (_NewLanguage == null)
                {
                    _NewLanguage = new RelayCommand(x => NewLanguage());
                }
                return _NewLanguage;
            }
        }

        private ICommand _DeleteLanguage;
        public ICommand DeleteLanguageCommand
        {
            get
            {
                if (_DeleteLanguage == null)
                {
                    _DeleteLanguage = new RelayCommand(x => Languages.Remove(SelectedLanguage), x => DeleteLanguage_CanExecute());
                }
                return _DeleteLanguage;
            }
        }
        private bool DeleteLanguage_CanExecute() { if (SelectedLanguage != null && SelectedLanguage.UseCount == 0) return true; else return false; }


        public void Save()
        {
            DataContext.Instance.Languages.Clear();
            Languages.ToList().ForEach(x => DataContext.Instance.Languages.Add(x.Language_Model));
        }



        private ICommand _ShowAddRemoveHelp;
        public ICommand ShowAddRemoveHelpCommand
        {
            get
            {
                if (_ShowAddRemoveHelp == null)
                {
                    _ShowAddRemoveHelp = new RelayCommand(x => ShowAddRemoveHelpCommand_Execute());
                }
                return _ShowAddRemoveHelp;
            }
        }
        private void ShowAddRemoveHelpCommand_Execute()
        {
            HelpViewModel vm = new HelpViewModel("Sprachen hinzufügen und löschen", "Um eine Sprache zu löschen, dürfen keine Verweise mehr auf ihr liegen. \nBedenke, dass die Sprachen nur für die atuelle Datei gelten.");
            HelpDialog dialog = new HelpDialog(vm); dialog.ShowDialog();

        }


    }
}
