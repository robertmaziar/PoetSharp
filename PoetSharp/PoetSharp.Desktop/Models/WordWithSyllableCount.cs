using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetSharp.Desktop.Models
{
    public class WordWithSyllableCount
    {
        public string Word { get; set; }
        public int SyllableCount { get; set; }
    }

    public class Sentence
    {
        public List<WordWithSyllableCount> WordGroup { get; set; }
    }

}
