using SnippetLibrary.Model;
using SnippetLibrary.View.DialogViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;

namespace SnippetLibrary.Context
{
    public class DataContext
    {
        public List<Language> Languages { get; set; }
        public List<Snippet> Snippets { get; set; }


        private DataContext()  // Damit kein Objekt angelegt werden kann
        {
        }
        public static DataContext Instance { get; } = new DataContext();



        public void SaveToFile(string fileName)
        {
            try
            {
                //TempVerzeichnis erstellen
                string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\tempSave";
                if (Directory.Exists(tempPath)) Directory.Delete(tempPath, true); //Sichergehen, dass das Verzeichnis nicht exisitiert.
                Directory.CreateDirectory(tempPath);

                //Datein Speichern
                Serializer.SaveXML(tempPath + "\\languages.slif", Languages);
                Serializer.SaveXML(tempPath + "\\snippets.slif", Snippets);

                //Dateien zu Zip Verzeichnis
                ZipFile.CreateFromDirectory(tempPath, fileName);
            }
            catch (Exception ex)
            {
                ErrorDialog dialog = new ErrorDialog(new ViewModel.DialogViewModels.SpecialDialogs.ErrorDialogViewModel("Die Datei konnte nicht gespeichert werden", ex));
                dialog.ShowDialog();
            }
        }

        public void LoadFromFile(string fileName)
        {
            try
            {
                //Temp Verzeichnis
                string tempPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\tempLoad";
                if (Directory.Exists(tempPath)) Directory.Delete(tempPath, true); //Sichergehen, dass das Verzeichnis nicht exisitiert.
                Directory.CreateDirectory(tempPath);

                //Zip datei entpacken
                ZipFile.ExtractToDirectory(fileName, tempPath);

                Snippets = Serializer.LoadXML<List<Snippet>>(tempPath + "\\snippets.slif");
                Languages = Serializer.LoadXML<List<Language>>(tempPath + "\\languages.slif");

                Directory.Delete(tempPath, true);
            }
            catch (Exception ex)
            {
                ErrorDialog dialog = new ErrorDialog(new ViewModel.DialogViewModels.SpecialDialogs.ErrorDialogViewModel("Die Datei konnte nicht geöffnet werden", ex));
                dialog.ShowDialog();
            }
        }

        public void ClearAllData()
        {
            Snippets = new List<Snippet>();
            Languages = new List<Language>();
        }
    }





    internal static class Serializer
    {
        public static void SaveXML<K>(string filename, K serializedObject)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(K));
                FileStream fs = new FileStream(filename, FileMode.Create);
                xml.Serialize(fs, serializedObject);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static K LoadXML<K>(string filename)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(K));
                K ret;
                FileStream fs = new FileStream(filename, FileMode.Open);
                ret = (K)xml.Deserialize(fs);
                fs.Close();
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
