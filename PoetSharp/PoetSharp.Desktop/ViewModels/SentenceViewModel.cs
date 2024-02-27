using PoetSharp.Desktop.Models;
using PoetSharp.Desktop.Services;
using System.Collections.Generic;
using System.Linq;

namespace PoetSharp.Desktop.ViewModels
{
    public class SentenceViewModel : ViewModelBase
    {

        private readonly ISentenceService _sentenceService;
        private readonly Sentence _sentence;

        public SentenceViewModel(Sentence sentence, ISentenceService sentenceService)
        {
            _sentence = sentence;
            _sentenceService = sentenceService;
        }

        public List<WordViewModel> Words => _sentence.Words.Select(o => new WordViewModel(o, _sentenceService)).ToList();
    }
}
