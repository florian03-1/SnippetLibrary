using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetLibrary.Model.Settings
{
    public class SettingValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string DefaultValue { get; set; }
        public bool IsAutomatedValue { get; set; }
        public override string ToString()
        {
            return $"Key: '{Key}', Value: '{Value}', DefaultValue: '{DefaultValue}', IsAutomatedValue: '{IsAutomatedValue.ToString()}'";
        }

    }
}
