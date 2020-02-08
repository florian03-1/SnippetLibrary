using Microsoft.Win32;
using SnippetLibrary.Context;
using SnippetLibrary.Model;
using SnippetLibrary.View.DialogViews;
using SnippetLibrary.ViewModel.DialogViewModels.SpecialDialogs;
using SnippetLibrary.ViewModel.Infrastructure;
using SnippetLibrary.ViewModel.ModelViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace SnippetLibrary.ViewModel.WorkspaceViewModels
{
    public class MainWorkspaceViewModel : ViewModelBase
    {
        public MainWorkspaceViewModel()
        {
            if (IsInDesignMode)
            {
                List<Language> Languages = new List<Language>();
                List<Snippet> Snippets = new List<Snippet>();

                //Languages
                Guid gl_01 = Guid.NewGuid(); Language l_01 = new Language(); l_01.ID = gl_01; l_01.Name = "VB"; Languages.Add(l_01);
                Guid gl_02 = Guid.NewGuid(); Language l_02 = new Language(); l_02.ID = gl_02; l_02.Name = "C#"; Languages.Add(l_02);


                //SnippetEnitries

                Guid gse_01 = Guid.NewGuid(); SnippetEnitry se_01 = new SnippetEnitry(); se_01.Name = "MainWindow.cs"; se_01.SnippetText = "private Tag s = new Tag();"; se_01.LanguageID = gl_02;
                Guid gse_05 = Guid.NewGuid(); SnippetEnitry se_05 = new SnippetEnitry(); se_05.Name = "Program.cs"; se_05.SnippetText = "for (int i = 0; i < 10; i++)\n{\n\n}"; se_05.LanguageID = gl_02;
                Guid gse_02 = Guid.NewGuid(); SnippetEnitry se_02 = new SnippetEnitry(); se_02.Name = "OverviewViewModel.vb"; se_02.SnippetText = "CollectionView.Filter = AdressOf Filter;"; se_02.LanguageID = gl_01;
                Guid gse_03 = Guid.NewGuid(); SnippetEnitry se_03 = new SnippetEnitry(); se_03.Name = "SnippetViewModel.cs"; se_03.SnippetText = "RaisePropertyChanged();"; se_03.LanguageID = gl_02;
                Guid gse_04 = Guid.NewGuid(); SnippetEnitry se_04 = new SnippetEnitry(); se_04.Name = "Calculator.vb"; se_04.SnippetText = "Dim i As Integer /ni += 1"; se_04.LanguageID = gl_01;


                //Snippets
                Guid gs_01 = Guid.NewGuid(); Snippet s_01 = new Snippet(); s_01.CreatedAt = DateTime.Parse("23.05.2014"); s_01.CreatedBy = "flori2212"; s_01.LanguageID = gl_02; s_01.ID = gs_01; s_01.Name = "ViewModel mit Daten füllen"; s_01.SnippetEnitries.Add(se_02); s_01.SnippetEnitries.Add(se_03); s_01.Tags = "Csharp, VisualBasi´c, Codebehind";
                Guid gs_02 = Guid.NewGuid(); Snippet s_02 = new Snippet(); s_02.CreatedAt = DateTime.Parse("02.12.2016"); s_02.CreatedBy = "Nofear23M"; s_02.LanguageID = gl_01; s_02.ID = gs_02; s_02.Name = "Rechner programmieren"; s_02.SnippetEnitries.Add(se_04); s_02.Tags = "Codebehind, ViewModel";
                Guid gs_03 = Guid.NewGuid(); Snippet s_03 = new Snippet(); s_03.CreatedAt = DateTime.Parse("12.01.2017"); s_03.CreatedBy = "Asusdk"; s_03.LanguageID = gl_02; s_03.ID = gs_03; s_03.Name = "Schleifen und anderes"; s_03.SnippetEnitries.Add(se_05); s_03.SnippetEnitries.Add(se_01); s_03.Tags = "ViewModel";
                Guid gs_04 = Guid.NewGuid(); Snippet s_04 = new Snippet(); s_04.CreatedAt = DateTime.Parse("30.08.2019"); s_04.CreatedBy = "MichaHo"; s_04.LanguageID = gl_01; s_04.ID = gs_04; s_04.Name = "Allgemeine Kenntnisse"; s_04.SnippetEnitries.Add(se_04); s_04.SnippetEnitries.Add(se_02); s_04.SnippetEnitries.Add(se_01); s_04.Tags = "Codebehind, ViewModel, XAML";
                Snippets.Add(s_01); Snippets.Add(s_02); Snippets.Add(s_03); Snippets.Add(s_04);
                List<LanguageViewModel> languageVM = new List<LanguageViewModel>(); Languages.ForEach(x => languageVM.Add(new LanguageViewModel(x)));


                Snippets.ForEach(x => AllSnippets.Add(new SnippetViewModel(x, languageVM)));
                IsFileOpen = true;
                OpenFileName = "sdfsfs";
            }
            else
            {
                AllSnippets = new ObservableCollection<SnippetViewModel>();
            }


            Init();
        }

        private void Init()
        {
            SelectedSnippet = AllSnippets.FirstOrDefault();

            AllSnippetsView = CollectionViewSource.GetDefaultView(AllSnippets);
            AllSnippetsView.Filter = AllSnippetsView_Filter;
            AllSnippetsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            AllSnippetsView.GroupDescriptions.Add(new PropertyGroupDescription("Language"));
        }


        #region Snippet, SelectedSnippet, View
        //Snippet, SelectedSnippet, View

        private ObservableCollection<SnippetViewModel> _AllSnippets;
        public ObservableCollection<SnippetViewModel> AllSnippets
        {
            get { return _AllSnippets; }
            set { _AllSnippets = value; RaisePropertyChanged(); }
        }

        private SnippetViewModel _SelectedSnippet;
        public SnippetViewModel SelectedSnippet
        {
            get { return _SelectedSnippet; }
            set { _SelectedSnippet = value; RaisePropertyChanged(); }
        }

        private ICollectionView _AllSnippetsView;
        public ICollectionView AllSnippetsView
        {
            get { return _AllSnippetsView; }
            set { _AllSnippetsView = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Filterlogic
        //Filterlogic

        private string _FilterText;
        public string FilterText
        {
            get
            {
                return _FilterText;
            }
            set
            {
                _FilterText = value; AllSnippetsView.Refresh(); RaisePropertyChanged();
            }
        }

        private bool AllSnippetsView_Filter(object obj)
        {
            if (String.IsNullOrEmpty(FilterText)) return true;

            SnippetViewModel currentSnippet = (SnippetViewModel)obj;
            string lowerFilterText = FilterText.ToLower();

            if (currentSnippet.Name.ToLower().Contains(lowerFilterText)) return true;
            if (currentSnippet.Language.Name.ToLower().Contains(lowerFilterText)) return true;
            if (currentSnippet.Tags.ToLower().Contains(lowerFilterText)) return true;

            return false;
        }
        #endregion

        #region Other
        //Other


        private bool _IsFileOpen;
        public bool IsFileOpen
        {
            get { return _IsFileOpen; }
            set { _IsFileOpen = value; RaisePropertyChanged(); }
        }

        private string _OpenFileName;
        public string OpenFileName
        {
            get { return _OpenFileName; }
            set { _OpenFileName = value; RaisePropertyChanged(); RaisePropertyChanged("WindowTitle"); }
        }

        public string WindowTitle
        {
            get
            {
                string s = "SnippetLibrary";
                if (IsFileOpen)
                {
                    s += " - " + new FileInfo(OpenFileName).Name;
                }
                else
                {
                    s += " - keine Datei geöffnet";
                }
                return s;
            }
        }

        #endregion

        //Settings

        public bool S_UImainWorkspace_SimpleListBoxStyle
        {
            get { return false; }  //Boolean.Parse( SettingsContext.Instance.GetSettingValue("UImainWorkspace_SimpleListBoxStyle"))
        }

        //--------  Methods  ------------

        public void Load(string fileName = null)
        {
            if (fileName != null)
            {
                DataContext.Instance.ClearAllData();
                DataContext.Instance.LoadFromFile(fileName);
                IsFileOpen = true;
                OpenFileName = fileName;
                RaisePropertyChanged("OpenFileName");
            }

            List<LanguageViewModel> languagesVM = new List<LanguageViewModel>();
            List<SnippetViewModel> snippetsVM = new List<SnippetViewModel>();

            DataContext.Instance.Languages.ForEach(x => languagesVM.Add(new LanguageViewModel(x)));
            DataContext.Instance.Snippets.ForEach(x => snippetsVM.Add(new SnippetViewModel(x, languagesVM)));

            AllSnippets = new ObservableCollection<SnippetViewModel>();
            snippetsVM.ForEach(x => AllSnippets.Add(x));

            Init();
        }

        public void NewFile()
        {
            if (IsFileOpen)
            {
                MessageBoxResult result = AskForSaveFile();
                if (MessageBoxResult.Yes == result) SaveFile();
                else if (MessageBoxResult.Cancel == result) return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Neue Datei anlegen...",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "SnippetDataBase *sdb|*.sdb"
            };

            if (sfd.ShowDialog() == true)
            {
                DataContext.Instance.ClearAllData();

                //Sprachen einspeichern:
                Language vb = new Language { ID = Guid.NewGuid(), Name = "VB" }; Language cs = new Language { ID = Guid.NewGuid(), Name = "C#" }; Language html = new Language { ID = Guid.NewGuid(), Name = "HTML" }; Language css = new Language { ID = Guid.NewGuid(), Name = "CSS" };
                List<Language> languages = new List<Language> { vb, cs, html, css };
                DataContext.Instance.Languages = languages;
                DataContext.Instance.SaveToFile(sfd.FileName);
                Load(sfd.FileName);
            }

        }
        public void OpenFile()
        {
            if (IsFileOpen)
            {
                MessageBoxResult result = AskForSaveFile();
                if (MessageBoxResult.Yes == result) SaveFile();
                else if (MessageBoxResult.Cancel == result) return;
            }

            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Snippet Library öffnen...",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "SnippetDataBase *sdb|*.sdb"
            };

            if (ofd.ShowDialog() == true)
            {
                Load(ofd.FileName);
            }
        }
        public void SaveFile()
        {
            System.IO.File.Delete(OpenFileName);
            DataContext.Instance.SaveToFile(OpenFileName);
        }
        public void SaveFileAs()
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Datei speichern als...",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "SnippetDataBase *sdb|*.sdb"
            };

            if (sfd.ShowDialog() == true)
            {
                DataContext.Instance.SaveToFile(sfd.FileName);
                Load(sfd.FileName);
            }
        }


        // Löschen, Bearbeiten, Neues Snippet

        private void NewSnippet()
        {
            win_addSnippetDialog dialog = new win_addSnippetDialog(new DialogViewModels.AddSnippetDialogViewModel());
            if (dialog.ShowDialog() == true)
            {
                Load(null);
            }
        }


        private void EditSnippet() //nur verfügbar, wenn SelectedSnippet != null ist
        {
            win_editSnippetDialog dialog = new win_editSnippetDialog(new DialogViewModels.EditSnippetDialogViewModel(SelectedSnippet.ID));
            dialog.ShowDialog();
            Load(null);
        }
        private void DeleteSnippet() //nur verfügbar, wenn SelectedSnippet != null ist
        {
            if (MessageBox.Show("Wollen sie den Snippet Eintrag wirklich löschen?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                AllSnippets.Remove(AllSnippets.FirstOrDefault(x => x.ID == SelectedSnippet.ID));
                DataContext.Instance.Snippets = new List<Snippet>();
                AllSnippets.ToList().ForEach(x => DataContext.Instance.Snippets.Add(x.Snippet_Model));
                SelectedSnippet = AllSnippets.FirstOrDefault();
            }
        }

        public MessageBoxResult AskForSaveFile()
        {
            return MessageBox.Show("Möchten sie die Änderungen speichern?", "Warnung", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
        }




        #region Commands


        private ICommand _LanguageManager;
        public ICommand LanguageManagerCommand
        {
            get
            {
                if (_LanguageManager == null)
                {
                  _LanguageManager = new RelayCommand(x => LanguageManager(), x => IsFileOpen);
                }
                return _LanguageManager;
            }
        }

        private void LanguageManager()
        {
            win_manageLanguagesDialog dialog = new win_manageLanguagesDialog(new DialogViewModels.ManageLanguagesDialogViewModel());
            dialog.ShowDialog();
            Load(null);
        }

        private ICommand _NewFile;
        public ICommand NewFileCommand
        {
            get
            {
                if (_NewFile == null)
                {
                    _NewFile = new RelayCommand(x => NewFile());
                }
                return _NewFile;
            }
        }


        private ICommand _OpenFile;
        public ICommand OpenFileCommand
        {
            get
            {
                if (_OpenFile == null)
                {
                    _OpenFile = new RelayCommand(x => OpenFile());
                }
                return _OpenFile;
            }
        }

        private ICommand _SaveFile;
        public ICommand SaveFileCommand
        {
            get
            {
                if (_SaveFile == null)
                {
                    _SaveFile = new RelayCommand(x => SaveFile(), x => IsFileOpen);
                }
                return _SaveFile;
            }
        }

        private ICommand _SaveFileAs;
        public ICommand SaveFileAsCommand
        {
            get
            {
                if (_SaveFileAs == null)
                {
                    _SaveFileAs = new RelayCommand(x => SaveFileAs(), x => IsFileOpen);
                }
                return _SaveFileAs;
            }
        }




        private ICommand _NewSnippet;
        public ICommand NewSnippetCommand
        {
            get
            {
                if (_NewSnippet == null)
                {
                    _NewSnippet = new RelayCommand(x => NewSnippet(), x => IsFileOpen);
                }
                return _NewSnippet;
            }
        }

        private ICommand _EditSnippet;
        public ICommand EditSnippetCommand
        {
            get
            {
                if (_EditSnippet == null)
                {
                    _EditSnippet = new RelayCommand(x => EditSnippet(), x => SelectedSnippet != null);
                }
                return _EditSnippet;
            }
        }
        private ICommand _DeleteSnippet;
        public ICommand DeleteSnippetCommand
        {
            get
            {
                if (_DeleteSnippet == null)
                {
                    _DeleteSnippet = new RelayCommand(x => DeleteSnippet(), x => SelectedSnippet != null);
                }
                return _DeleteSnippet;
            }
        }

        private ICommand _CloseApplication;
        public ICommand CloseApplicationCommand
        {
            get
            {
                if (_CloseApplication == null)
                {
                    _CloseApplication = new RelayCommand(x => Environment.Exit(0));
                }
                return _CloseApplication;
            }
        }

        private ICommand _ShowAboutDialog;
        public ICommand ShowAboutDialogCommand
        {
            get
            {
                if (_ShowAboutDialog == null)
                {
                    _ShowAboutDialog = new RelayCommand(x => ShowAboutDialgoCommand_Execute());
                }
                return _ShowAboutDialog;
            }
        }

        private ICommand _FirstHelp;
        public ICommand FirstHelpCommand
        {
            get
            {
                if (_FirstHelp == null)
                {
                    _FirstHelp = new RelayCommand(x => FirstHelpCommand_Execute());
                }
                return _FirstHelp;
            }
        }
        private void FirstHelpCommand_Execute()
        {
            HelpViewModel vm = new HelpViewModel("Allgemeine Bedinung", "Um eine neue Datei anzulegen gehen sie auf Datei>Neu\nUm einer geöffneten Datei ein Snippet hinzuzufügen, gehen sie auf Snippet>Neu");
            HelpDialog dialog = new HelpDialog(vm); dialog.ShowDialog();
        }


        private ICommand _CopyToClipboard;
        public ICommand CopyToClipboardCommand
        {
            get
            {
                if (_CopyToClipboard == null)
                {
                    _CopyToClipboard = new RelayCommand(x => Clipboard.SetText(SelectedSnippet.SelectedSnippetEnitry.SnippetText), x => SelectedSnippet != null && SelectedSnippet.SelectedSnippetEnitry != null);
                }
                return _CopyToClipboard;
            }
        }

        private void ShowAboutDialgoCommand_Execute()
        {
            AboutDialog dialog = new AboutDialog(); dialog.ShowDialog();
        }


        #endregion

    }
}
