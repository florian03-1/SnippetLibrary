using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.Context
{
    class InfoContext
    {

        private InfoContext()  // Damit kein Objekt angelegt werden kann
        {
        }
        public static InfoContext Instance { get; } = new InfoContext();

        public string AppName
        {
            get { return "SnippetLibrary"; }
        }

        public Version AppVersion
        {
            get { return new Version(1, 1, 0); }   //Versionsnummer
        }

        public string AppDescription
        {
            get { return "Ein simples Programm um CodeSnippets zu kategorisieren, speichern, sortieren und suchen."; }
        }

        public string Copyright
        {
            get { return "(c) 2020 by Florian"; }
        }

        public string LicenceName
        {
            get { return "GNU General Public Licence"; }
        }
        public string LicenceText
        {
            get { return "GNU General Public Licence"; }
        }


        public List<UsedLibrariesItem> AllUsedLibraries
        {
            get
            {
                List<UsedLibrariesItem> list = new List<UsedLibrariesItem>();
                list.Add(new UsedLibrariesItem("AvalonEdit", "Ein Texteditor mit Syntaxhighlithing", "6.0.1"));
                list.Add(new UsedLibrariesItem("Extended.Wpf.Toolkit", "Einige WPF Controls","3.8.1"));
                return list;
            }
        }
    }



    public class UsedLibrariesItem
    {
        public UsedLibrariesItem()
        {
        }

        public UsedLibrariesItem(string name, string description, string version)
        {

            Name = name;
            Description = description;
            Version = version;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }


}
