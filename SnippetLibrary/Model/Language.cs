using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.Model
{
    public class Language
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public Language() { ID = Guid.NewGuid(); }
    }
}
