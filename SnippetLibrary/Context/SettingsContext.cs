using SnippetLibrary.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnippetLibrary.Context
{
    public class SettingsContext
    {

        private SettingsContext()  // Damit kein Objekt angelegt werden kann
        {
        }
        public static SettingsContext Instance { get; } = new SettingsContext();


        public List<SettingValue> Settings { get; set; }

        public void Load(string specialPath = null)
        {
            try
            {
                string path = "";
                if (specialPath != null && File.Exists(specialPath)) path = specialPath;
                else path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SnippetLibrary\\settings.sls";

                if (!File.Exists(path)) { Settings = new List<SettingValue>(); CheckIfAllSettingsAviable(); }   //Wenn noch keine Settings da, dann settings mit Standartwerten erstellen
                else Settings = Serializer.LoadXML<List<SettingValue>>(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(string specialPath = null)
        {
            CheckIfAllSettingsAviable();

            try
            {
                string path = "";
                FileInfo fInfo = new FileInfo(specialPath);
                if (specialPath != null && Directory.Exists(fInfo.DirectoryName)) path = specialPath;
                else path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SnippetLibrary\\settings.sls";
                Serializer.SaveXML(path, Settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string GetSettingValue(string key)
        {
            return Settings.Find(x => x.Key == key).Value;
        }
        public SettingValue GetSetting(string key)
        {
            return Settings.Find(x => x.Key == key);
        }


        public void SetSettingValue(string key, string value)
        {
            Settings.Find(x => x.Key == key).Value = value;
        }
        public void SetSetting(SettingValue setting)
        {
            Settings.Remove( Settings.Find(x => x.Key == setting.Key));
            Settings.Add(setting);
        }

        public int CheckIfAllSettingsAviable()
        {
            if (Settings == null) Settings = new List<SettingValue>(); //Wenn settins noch gar nicht erstellt wurde...
            int unaviable = 0;
            List<SettingValue> allSettings = new List<SettingValue>();
            SettingValue ui_showIdUnderName = new SettingValue() { Key = "ui_schowIdUnderName", Value = Boolean.TrueString, DefaultValue = Boolean.TrueString, IsAutomatedValue = false }; allSettings.Add(ui_showIdUnderName);
            SettingValue startup_loadRecentDatabase = new SettingValue() { Key = "startup_loadRecentDatabase", Value = Boolean.FalseString, DefaultValue = Boolean.FalseString, IsAutomatedValue = false }; allSettings.Add(startup_loadRecentDatabase);
            SettingValue startup_recentFile = new SettingValue() { Key = "startup_recentFile", Value = "", DefaultValue = "", IsAutomatedValue = true }; allSettings.Add(startup_recentFile);

            foreach (SettingValue settingValue in allSettings)
            {
                bool found = false;
                foreach (SettingValue existingSetting in Settings)
                {
                    if (settingValue.Key == existingSetting.Key) found = true;
                }
                if (found == false) { unaviable += 1; Settings.Add(settingValue);}
            }
            return unaviable;
        }
    }
}
