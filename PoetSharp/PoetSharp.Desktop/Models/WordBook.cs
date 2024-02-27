using System.Collections.Generic;

namespace PoetSharp.Desktop.Models
{
    public class WordBook
    {
        Dictionary<string, string> Definitions = new Dictionary<string, string>();

        public WordBook(Dictionary<string, string> definitions)
        {
            Definitions = definitions;
        }
    }
}
