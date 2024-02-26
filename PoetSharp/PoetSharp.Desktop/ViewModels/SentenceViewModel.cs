using PoetSharp.Desktop.Models;
using System.Collections.Generic;
using System.Linq;

namespace PoetSharp.Desktop.ViewModels
{
    public class SentenceViewModel : ViewModelBase
    {
        private readonly Sentence _sentence;

        public SentenceViewModel(Sentence sentence)
        {
            _sentence = sentence;
        }

        public List<WordViewModel> Words => _sentence.Words.Select(o => new WordViewModel(o)).ToList();
    }
}
