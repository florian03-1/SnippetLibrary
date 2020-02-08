using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.Model
{
    public class SnippetEnitry
    {
        public Guid LanguageID { get; set; }
        public string Name { get; set; }
        public string SnippetText { get; set; }
    }
}
