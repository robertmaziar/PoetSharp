using System.Collections.Generic;

namespace PoetSharp.Desktop.Models
{
    public class WordBookDefinition
    {
        KeyValuePair<string, string> Definition = new KeyValuePair<string, string>();

        public WordBookDefinition(KeyValuePair<string, string> definition)
        {
            Definition = definition;
        }
    }
}
