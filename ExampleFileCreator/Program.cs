using SnippetLibrary.Context;
using SnippetLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleFileCreator
{
    class Program
    {
        public static List<Language> Languages { get; set; }
        public static List<Snippet> Snippets { get; set; }


        static void Main(string[] args)
        {


            Languages = new List<Language>(); Snippets = new List<Snippet>();

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

            Guid gs_01 = Guid.NewGuid(); Snippet s_01 = new Snippet(); s_01.CreatedAt = DateTime.Parse("23.05.2014"); s_01.CreatedBy = "flori2212"; s_01.LanguageID = gl_02; s_01.ID = gs_01; s_01.Name = "ViewModel mit Daten füllen"; s_01.SnippetEnitries.Add(se_02); s_01.SnippetEnitries.Add(se_03); s_01.Tags = "ViewModel, MVVM";
            Guid gs_02 = Guid.NewGuid(); Snippet s_02 = new Snippet(); s_02.CreatedAt = DateTime.Parse("02.12.2016"); s_02.CreatedBy = "Nofear23M"; s_02.LanguageID = gl_01; s_02.ID = gs_02; s_02.Name = "Rechner programmieren"; s_02.SnippetEnitries.Add(se_04); s_02.Tags = "MVVM, CodeBehind, DataContext";
            Guid gs_03 = Guid.NewGuid(); Snippet s_03 = new Snippet(); s_03.CreatedAt = DateTime.Parse("12.01.2017"); s_03.CreatedBy = "Asusdk"; s_03.LanguageID = gl_02; s_03.ID = gs_03; s_03.Name = "Schleifen und anderes"; s_03.SnippetEnitries.Add(se_05); s_03.SnippetEnitries.Add(se_01); s_03.Tags = "DataContext, ViewModel, C#";
            Guid gs_04 = Guid.NewGuid(); Snippet s_04 = new Snippet(); s_04.CreatedAt = DateTime.Parse("30.08.2019"); s_04.CreatedBy = "MichaHo"; s_04.LanguageID = gl_01; s_04.ID = gs_04; s_04.Name = "Allgemeine Kenntnisse"; s_04.SnippetEnitries.Add(se_04); s_04.SnippetEnitries.Add(se_02); s_04.SnippetEnitries.Add(se_01); s_04.Tags = "DataContext, XML, Serialisierung";
            Snippets.Add(s_01); Snippets.Add(s_02); Snippets.Add(s_03); Snippets.Add(s_04);

            DataContext.Instance.Languages = Languages;
            DataContext.Instance.Snippets = Snippets;

            //DataContext.Instance.SaveToFile("C:\\Users\\Florian\\Desktop\\testdatei.sdb");

            //SettingsContext.Instance.Save("C:\\Users\\Florian\\Desktop\\settings.sls");

            SettingsContext.Instance.CheckIfAllSettingsAviable();
            SettingsContext.Instance.Settings.ForEach(x => Console.WriteLine(x.ToString()));
            Console.WriteLine("\n");
            Console.WriteLine(SettingsContext.Instance.GetSettingValue("startup_loadRecentDatabase"));
            Console.ReadKey();

        }


    }
}
