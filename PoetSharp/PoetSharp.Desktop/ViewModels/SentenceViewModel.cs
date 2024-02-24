using PoetSharp.Desktop.Models;
using System.Collections.Generic;

namespace PoetSharp.Desktop.ViewModels
{
    public class SentenceViewModel : ViewModelBase
    {
        private readonly Sentence _sentence;

        public SentenceViewModel(Sentence sentence)
        {
            _sentence = sentence;
        }

        public List<Word> Words => _sentence.Words;
    }
}
