using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.Model
{
    public class Snippet : ICloneable
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<SnippetEnitry> SnippetEnitries { get; set; }

        public Guid LanguageID { get; set; }

        public string Tags { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public Snippet()
        {
            ID = Guid.NewGuid();
            SnippetEnitries = new List<SnippetEnitry>();

            CreatedAt = DateTime.Now;
            CreatedBy = Environment.UserName;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
